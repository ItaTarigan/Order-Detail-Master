using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class ElementServices : System.Web.UI.Page
    {
        SMLPOBModel context = new SMLPOBModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RefreshGrid();
            BtnAdd.Click += BtnAdd_Click;
            BtnSubmit.Click += BtnSubmit_Click;
            BtnCancel.Click += BtnCancel_Click;
            GvData.RowCommand += GvData_RowCommand;
            dropdowncmd();
            //checkmenu();
        }
        //void checkmenu()
        //{
        //    permission NewItem = null;
        //    var IDS = (from x in context.permissions
        //               select x).ToList();
        //    string path = HttpContext.Current.Request.Url.AbsolutePath;

        //    string loginrole = Roles.GetRolesForUser().FirstOrDefault();

        //    foreach (GridViewRow row in GvData.Rows)
        //    {
        //        if (IDS.Any(x => x.Role == loginrole) && IDS.Any(x => x.PageUrl == path))
        //        {
        //            NewItem = (from x in IDS
        //                       where x.Role == loginrole && x.PageUrl == path
        //                       select x).FirstOrDefault();

        //            if (NewItem == null)
        //            {
        //                Response.Redirect("/Pages/Private/DenyAccess.aspx");
        //            }
        //            else
        //            {
        //                ((LinkButton)row.Cells[0].FindControl("Edit")).Visible = NewItem.CanEdit.Value;
        //                ((LinkButton)row.Cells[0].FindControl("Lihat")).Visible = NewItem.CanView.Value;
        //                ((LinkButton)row.Cells[0].FindControl("Delete")).Visible = NewItem.CanDelete.Value;
        //                BtnAdd.Visible = NewItem.CanAdd.Value;
        //            }
        //        }
        //    }
        //}
        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "Ubah":
                    SetLayout(ModeForm.EditData);
                    LoadDetail(IDS.ToString());
                    break;
                case "Hapus":
                    var datas = from x in context.elementservicestbls
                                where x.elementCode == IDS.ToString()
                                select x;
                    foreach (var item in datas)
                    {
                        context.elementservicestbls.Remove(item);
                    }
                    context.SaveChanges();
                    RefreshGrid();
                    break;
                case "Lihat":
                    SetLayout(ModeForm.LihatData);
                    LoadDetail(IDS.ToString());

                    break;
            }
        }

        enum ModeForm { ViewGrid, EditData, LihatData }
        void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.EditData:
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnSubmit.Visible = true;
                    break;
                case ModeForm.LihatData:
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnSubmit.Visible = false;
                    break;
                case ModeForm.ViewGrid:
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SetLayout(ModeForm.ViewGrid);
            RefreshGrid();
            //checkmenu();
        }

        void LoadDetail(string fid)
        {
            var seldata = from x in context.elementservicestbls
                          where x.elementCode == fid
                          select x;
            foreach (var item in seldata)
            {
                //TxtelementCode.Text = item.elementCode.ToString();
                TxtElementCode.Text = item.elementCode;
                AnaylysisName.Text = item.analysisTypeName;
                TxtServiceGroup.Text = item.serviceGroup;
                TxtServiceRate.Text = item.serviceRate.ToString();
                TxtServiceStatus.Text = item.serviceStatus;
                //TxtID.Value = item.elementCode.ToString();
                break;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //update
                if (!string.IsNullOrEmpty(TxtElementCode.Text))
                {
                    var IDS = TxtElementCode.Text;
                    var NewItem = (from x in context.elementservicestbls
                                   where x.elementCode == IDS
                                   select x).FirstOrDefault();
                    NewItem.modBy = User.Identity.Name;
                    NewItem.modDate = DateTime.Now;
                    NewItem.elementCode = TxtElementCode.Text;
                    NewItem.analysisTypeName = AnaylysisName.SelectedValue;
                    NewItem.serviceGroup = TxtServiceGroup.Text;
                    NewItem.serviceRate = Convert.ToInt32(TxtServiceRate.Text);
                    NewItem.serviceStatus = TxtServiceStatus.Text;
                }
                else //add new
                {
                    var NewItem = new elementservicestbl() { };
                    NewItem.creaBy = "test";
                    NewItem.creaDate = DateTime.Now;
                    NewItem.elementCode = TxtElementCode.Text;
                    NewItem.analysisTypeName = AnaylysisName.SelectedValue;
                    NewItem.serviceGroup = TxtServiceGroup.Text;
                    NewItem.serviceRate = Convert.ToInt32(TxtServiceRate.Text);
                    NewItem.serviceStatus = TxtServiceStatus.Text;
                    context.elementservicestbls.Add(NewItem);


                }
                context.SaveChanges();
                PanelGrid.Visible = true;
                PanelInput.Visible = false;
                RefreshGrid();
            }
            catch (Exception ex)
            {
                TxtStatus.Text = "gagal save --> " + ex.Message;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //TxtCreated.Text = DateTime.Now.ToString();
            //TxtUpdated.Text = DateTime.Now.ToString();
            //TxtCreatedBy.Text = User.Identity.Name;
            //TxtUpdatedBy.Text = User.Identity.Name;
            PanelGrid.Visible = false;
            ClearFields();
            PanelInput.Visible = true;
        }

        void ClearFields()
        {
            //clear all field input
            TxtElementCode.Text = "";
            //TxtUpdatedBy.Text = "";
            //TxtCreated.Text = DateTime.Now.ToString();
            //TxtUpdated.Text = DateTime.Now.ToString();
            AnaylysisName.Text = "";
            //DDDerivative.Text = "";
            TxtServiceGroup.Text = "";
            TxtServiceRate.Text = "";
            TxtServiceStatus.Text = "";
            TxtStatus.Text = "";
        }

        void dropdowncmd()
        {
            using (var datacontext = new LinqDataSource())
            {
                var datas = from x in context.analysistypetbls
                            select x.analysisTypeName;
                AnaylysisName.DataSource = datas.ToList();
                AnaylysisName.DataTextField = "analysisTypeName";
                AnaylysisName.DataValueField = "analysisTypeName";
                AnaylysisName.DataBind();
            }
        }

        void RefreshGrid()
        {
            var datas = from x in context.elementservicestbls
                        select x;
            GvData.DataSource = datas.ToList();
            GvData.DataBind();

            if (GvData.Rows.Count > 0)
            {
                //This replaces <td> with <th>    
                GvData.UseAccessibleHeader = true;
                //This will add the <thead> and <tbody> elements    
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
                //This adds the <tfoot> element. Remove if you don't have a footer row    
                GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}