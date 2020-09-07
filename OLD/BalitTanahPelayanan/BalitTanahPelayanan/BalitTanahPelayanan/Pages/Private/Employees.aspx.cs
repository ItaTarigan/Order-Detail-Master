using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class Employees : System.Web.UI.Page
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
            var IDS = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Ubah":
                    SetLayout(ModeForm.EditData);
                    LoadDetail(IDS);
                    break;
                case "Hapus":
                    var datas = from x in context.employeetbls
                                where x.employeeNo == IDS
                                select x;
                    foreach (var item in datas)
                    {
                        context.employeetbls.Remove(item);
                    }
                    context.SaveChanges();
                    RefreshGrid();
                    break;
                case "Lihat":
                    SetLayout(ModeForm.LihatData);
                    LoadDetail(IDS);

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

        void LoadDetail(int fid)
        {
            var seldata = from x in context.employeetbls
                          where x.employeeNo == fid
                          select x;
            foreach (var item in seldata)
            {
                //TxtEmployeeNo.Text = item.employeeNo.ToString();
                TxtEmployeeName.Text = item.employeeName;
                TxtPosition.Text = item.position;
                TxtEmpEmail.Text = item.employeeEmail;
                Txtdvemp.Text = item.derivativeToEmployee.ToString();
                TxtAccountNo.Text = item.accountNo.ToString();
                TxtID.Value = item.employeeNo.ToString();
                break;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //update
                if (!string.IsNullOrEmpty(TxtID.Value))
                {
                    var IDS = int.Parse(TxtID.Value);
                    var NewItem = (from x in context.employeetbls
                                   where x.employeeNo == IDS
                                   select x).FirstOrDefault();
                    NewItem.modBy = User.Identity.Name;
                    NewItem.modDate = DateTime.Now;
                    NewItem.employeeName = TxtEmployeeName.Text;
                    NewItem.position = TxtPosition.Text;
                    NewItem.employeeEmail = TxtEmpEmail.Text;
                    NewItem.derivativeToEmployee = Convert.ToInt32(Txtdvemp.Text);
                    NewItem.accountNo = Convert.ToInt32(TxtAccountNo.Text);
                }
                else //add new
                {
                    var NewItem = new employeetbl() { };
                    NewItem.creaBy = "test";
                    NewItem.creaDate = DateTime.Now;
                    NewItem.employeeName = TxtEmployeeName.Text;
                    NewItem.position = TxtPosition.Text;
                    NewItem.employeeEmail = TxtEmpEmail.Text;
                    NewItem.derivativeToEmployee = Convert.ToInt32(Txtdvemp.Text);
                    NewItem.accountNo = Convert.ToInt32(TxtAccountNo.Text);
                    context.employeetbls.Add(NewItem);


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
            TxtID.Value = "";
            //TxtUpdatedBy.Text = "";
            //TxtCreated.Text = DateTime.Now.ToString();
            //TxtUpdated.Text = DateTime.Now.ToString();
            TxtEmployeeName.Text = "";
            TxtPosition.Text = "";
            TxtEmpEmail.Text = "";
            Txtdvemp.Text = "";
            TxtAccountNo.Text = "";
            TxtStatus.Text = "";
        }

        void RefreshGrid()
        {
            var datas = from x in context.employeetbls
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