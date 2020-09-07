using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class AnalysisTypes : System.Web.UI.Page
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
                    var datas = from x in context.analysistypetbls
                                where x.analysisTypeName == IDS.ToString()
                                select x;
                    foreach (var item in datas)
                    {
                        context.analysistypetbls.Remove(item);
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
            var seldata = from x in context.analysistypetbls
                          where x.analysisTypeName == fid
                          select x;
            foreach (var item in seldata)
            {
                //TxtcomodityNo.Text = item.comodityNo.ToString();
                TxtAnalysisTypeName.Text = item.analysisTypeName;
                TxtDescription.Text = item.description;
                //TxtID.Value = item.comodityNo.ToString();
                break;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //update
                if (!string.IsNullOrEmpty(TxtAnalysisTypeName.Text))
                {
                    var IDS = TxtAnalysisTypeName.Text;
                    var NewItem = (from x in context.analysistypetbls
                                   where x.analysisTypeName == IDS
                                   select x).FirstOrDefault();
                    NewItem.modBy = User.Identity.Name;
                    NewItem.modDate = DateTime.Now;
                    NewItem.analysisTypeName = TxtAnalysisTypeName.Text;
                    NewItem.description = TxtDescription.Text;
                }
                else //add new
                {
                    var NewItem = new analysistypetbl() { };
                    NewItem.creaBy = "test";
                    NewItem.creaDate = DateTime.Now;
                    NewItem.analysisTypeName = TxtAnalysisTypeName.Text;
                    NewItem.description = TxtDescription.Text;
                    context.analysistypetbls.Add(NewItem);
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
            //TxtID.Value = "";
            //TxtUpdatedBy.Text = "";
            //TxtCreated.Text = DateTime.Now.ToString();
            //TxtUpdated.Text = DateTime.Now.ToString();
            TxtAnalysisTypeName.Text = "";
            //DDDerivative.Text = "";
            TxtDescription.Text = "";
            TxtStatus.Text = "";
        }

        void RefreshGrid()
        {
            var datas = from x in context.analysistypetbls
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