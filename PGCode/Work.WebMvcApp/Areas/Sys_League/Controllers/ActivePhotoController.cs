﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ProcCore;
using ProcCore.WebCore;
using ProcCore.NetExtension;
using ProcCore.Business.LogicL;
using ProcCore.Business.Logic.TablesDescriptionL;
using ProcCore.ReturnAjaxResult;
using ProcCore.JqueryHelp.JQGridScript;
using DotWeb.CommSetup;
using Newtonsoft.Json;

namespace DotWeb.Areas.Sys_League.Controllers
{
    public class ActivePhotoController : BaseAction<m_ActivePhoto, a_ActivePhoto, q_ActivePhoto, ActivePhoto>
    {
        #region Action and function section

        public RedirectResult Index()
        {
            return Redirect(Url.Action("ListGrid"));
        }

        public override ActionResult ListGrid(q_ActivePhoto sh)
        {
            operationMode = OperationMode.EnterList;
            HandleRequest HRq = new HandleRequest(); //記錄QueryString            
            HRq.encodeURIComponent = true;
            HRq.Remove("page");

            ViewBag.Page = QueryGridPage();
            ViewBag.Caption = GetSystemInfo().prog_name;
            ViewBag.AppendQuertString = HRq.ToQueryString();
            HRq = null;

            return View("ListData", sh);
        }
        public override ActionResult EditMasterNewData()
        {
            operationMode = OperationMode.EditInsert;

            ac = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            md = new m_ActivePhoto() { id = ac.GetIDX() };
            md.EditType = EditModeType.Insert;
            #region 新增欄位預設值設定
            md.set_date = DateTime.Now;
            md.isopen = true;
            #endregion
            HandleCollectDataToOptions();

            ViewBag.Caption = GetSystemInfo().prog_name;

            HandleRequest HRq = new HandleRequest();  //記錄QueryString
            HRq.Remove("Id"); //不需記ID
            ViewBag.QueryString = HRq.ToQueryString();
            HRq = null;

            return View("EditData", md);
        }
        public override ActionResult EditMasterDataByID(int id)
        {
            operationMode = OperationMode.EditModify;
            ac = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunOneDataEnd<m_ActivePhoto> HResult = ac.GetDataMaster(id, LoginUserId);
            md = HResult.SearchData;
            md.EditType = EditModeType.Modify;
            HandleResultCheck(HResult);
            HandleCollectDataToOptions();

            ViewBag.Caption = GetSystemInfo().prog_name;

            HandleRequest HRq = new HandleRequest();  //記錄QueryString
            HRq.Remove("id"); //不需記ID
            ViewBag.QueryString = HRq.ToQueryString();
            HRq = null;

            return View("EditData", md);
        }

        protected override void HandleCollectDataToOptions()
        {
            //ViewBag.NewsKind_Option = MakeCollectDataToOptions(CodeSheet.NewsKind.ToDictionary(), false);
        }
        #endregion

        #region ajax call section
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_MasterUpdata(m_ActivePhoto md)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            String returnPicturePath = String.Empty;

            ac = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            if (md.EditType == EditModeType.Insert)
            {   //新增
                RunInsertEnd HResult = this.ac.InsertMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Insert_Success);
                rAjaxResult.id = HResult.InsertId;
            }
            else
            {
                //修改
                RunEnd HResult = this.ac.UpdateMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Update_Success);
                rAjaxResult.id = md.id;
            }
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        public override String ajax_MasterDeleteData(String id)
        {
            String returnString = string.Empty;

            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            ac = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunDeleteEnd HResult = ac.DeleteMaster(id.Split(',').CInt(), LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpGet]
        public override String ajax_MasterGridData(q_ActivePhoto queryObj)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            ac = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunQueryPackage<m_ActivePhoto> HResult = ac.SearchMaster(queryObj, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (queryObj.page == null ? 1 : queryObj.page.CInt());
            int startRecord = PageCount.PageInfo(page, this.DefPageSize, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(this.DefPageSize);
            foreach (m_ActivePhoto md in Modules)
            {
                List<String> setFields = new List<String>();

                setFields.Add(md.id.ToString());
                setFields.Add(md.title);
                setFields.Add(md.set_date.ToStandardDate());
                setFields.Add(md.isopen.BooleanValue(BooleanSheet.ynvx));
                setRowElement.Add(new RowElement() { id = md.id.ToString(), cell = setFields.ToArray() });
            }
            #endregion
            #region 回傳JSON資料

            return JsonConvert.SerializeObject(new JQGridDataObject()
            {
                rows = setRowElement.ToArray(),
                total = PageCount.TotalPage,
                page = PageCount.Page,
                records = PageCount.RecordCount
            }, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            #endregion
        }
        #endregion

        #region ajax file upload handle
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_UploadFine(int Id, String FilesKind, String hd_FileUp_EL)
        {
            //hd_FileUp_EL
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();

            #region
            String tpl_File = String.Empty;
            try
            {
                //判斷是否為圖片檔
                if (!IMGExtDef.Any(x => x == hd_FileUp_EL.GetFileExt()))
                {
                    HandFineSave(hd_FileUp_EL, Id, new FilesUpScope() { LimitCount = 1 }, FilesKind, false);
                    rAjaxResult.result = true;
                    rAjaxResult.success = true;
                    rAjaxResult.FileName = hd_FileUp_EL.GetFileName();
                }
                else
                {
                    if (FilesKind == "Single")
                        HandImageSave(hd_FileUp_EL, Id, ImageFileUpParm.Single, FilesKind);

                    if (FilesKind == "Double")
                        HandImageSave(hd_FileUp_EL, Id, ImageFileUpParm.Double, FilesKind);

                    if (FilesKind == "ListIcon")
                        HandImageSave(hd_FileUp_EL, Id, ImageFileUpParm.List, FilesKind);

                    rAjaxResult.result = true;
                    rAjaxResult.success = true;
                    rAjaxResult.FileName = hd_FileUp_EL.GetFileName();
                }
            }
            catch (LogicError ex)
            {
                rAjaxResult.result = false;
                rAjaxResult.success = false;
                rAjaxResult.error = GetRecMessage(ex.Message);
            }
            catch (Exception ex)
            {
                rAjaxResult.result = false;
                rAjaxResult.success = false;
                rAjaxResult.error = ex.Message;
            }
            #endregion
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        [ValidateInput(false)]
        public String ajax_ListFiles(int Id, String FileKind)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            rAjaxResult.filesObject = ListSysFiles(Id, FileKind);
            rAjaxResult.result = true;
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        [ValidateInput(false)]
        public String ajax_DeleteFiles(int Id, String FileKind, String FileName)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            DeleteSysFile(Id, FileKind, FileName, ImageFileUpParm.NewsBasic);
            rAjaxResult.result = true;
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        #endregion
    }
}