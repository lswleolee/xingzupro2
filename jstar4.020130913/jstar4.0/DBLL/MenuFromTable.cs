using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace DBLL
{
   public  class MenuFromTable
    {
        public DataTable dtSource = new DataTable();
        public string FatherIDColumnName = "";
        public string ItemTextColumnName = "";
        public string ItemValueColumnName = "";
        public string ItembIsClickColumnName = "";
        public string NavigateUrlColumnName = "";
        public bool bIsClick = false;
        public string RootItemText = "";
        public int nRootParentID = 0;

        public MenuFromTable()
        {
            dtSource = new DataTable();
            FatherIDColumnName = "";
            ItemTextColumnName = "";
            ItemValueColumnName = "";
            ItembIsClickColumnName = "";
            NavigateUrlColumnName = "";
            bIsClick = false;
        }
        public MenuItem[] GetMenuRootItems(DataTable dt)
        {
            try
            {
                dtSource = dt;
               

                return BindMenuItems(nRootParentID);
            }


            catch (Exception)
            {

                throw;
            }
        }

     
        //************************
        private MenuItem[] BindMenuItems(int nParentID)
        {
            //************************

            int _nMenuValue = 0;


            bool _bIsClick = false;
            bool _bIsPopup = false;
         
            DataRow[] _drs;
           
            //************************
            try
            {
                _drs = dtSource.Select(FatherIDColumnName + " = " + nParentID);
                MenuItem[] Items = new MenuItem[_drs.Length];
                for (int i = 0; i < _drs.Length; i++) 
                {
                    DataRow dr = _drs[i];
                    Items[i] = new MenuItem();

                    if (dtSource.Columns.IndexOf(ItemTextColumnName) >= 0)
                    {
                        Items[i].Text = dr[ItemTextColumnName].ToString();
                    }
                    else Items[i].Text = "null";


                    if (dtSource.Columns.IndexOf(ItemValueColumnName) >= 0)
                    {
                        int.TryParse(dr[ItemValueColumnName].ToString(), out _nMenuValue);
                        Items[i].Value = _nMenuValue.ToString();
                    }

                    if (dtSource.Columns.IndexOf(ItembIsClickColumnName) >= 0)
                    {
                        bool.TryParse(dr[ItembIsClickColumnName].ToString(), out _bIsClick);

                    }

                    if (bIsClick == true && dtSource.Columns.IndexOf(NavigateUrlColumnName) >= 0)
                    {

                        Items[i].NavigateUrl = dr[NavigateUrlColumnName].ToString();
                    }


                    if (_bIsPopup)
                    {
                        Items[i].Target = "_blank";
                    }
                    AddChildMenu(Items[i], _nMenuValue);
                }

                return Items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //************************
        private MenuItem BindMenuItems(MenuItem Itemroot, int nParentID)
        {
            //************************

            int _nMenuValue = 0;


            bool _bIsClick = false;
            bool _bIsPopup = false;

            DataRow[] _drs;
            MenuItem _miItem;
            //************************
            try
            {
                _drs = dtSource.Select(FatherIDColumnName + " = " + nParentID);

                foreach (DataRow dr in _drs)
                {
                    _miItem = new MenuItem();

                    if (dtSource.Columns.IndexOf(ItemTextColumnName) >= 0)
                    {
                        _miItem.Text = dr[ItemTextColumnName].ToString();
                    }
                    else _miItem.Text = "null";


                    if (dtSource.Columns.IndexOf(ItemValueColumnName) >= 0)
                    {
                        int.TryParse(dr[ItemValueColumnName].ToString(), out _nMenuValue);
                        _miItem.Value = _nMenuValue.ToString();
                    }

                    if (dtSource.Columns.IndexOf(ItembIsClickColumnName) >= 0)
                    {
                        bool.TryParse(dr[ItembIsClickColumnName].ToString(), out _bIsClick);

                    }

                    if (bIsClick == true && dtSource.Columns.IndexOf(NavigateUrlColumnName) >= 0)
                    {

                        _miItem.NavigateUrl = dr[NavigateUrlColumnName].ToString();
                    }


                    if (_bIsPopup)
                    {
                        _miItem.Target = "_blank";
                    }
                    //TreeView2.Items.AddAt(0,_miItem);
                    Itemroot.ChildItems.Add(_miItem);
                    //Menu1.Items.Add(_miItem);
                    AddChildMenu(_miItem, _nMenuValue);
                }

                return Itemroot;
            }
            catch (Exception ex)
            {
                return Itemroot;
            }
        }
        //************************
        private void AddChildMenu(MenuItem miItem, int nParentID)
        {
            //************************

            int _nMenuValue = 0;


            bool _bIsClick = false;
            bool _bIsPopup = false;

            DataRow[] _drs;
            MenuItem _miItem;
            //************************
            try
            {
                _drs = dtSource.Select(FatherIDColumnName + " = " + nParentID);

                foreach (DataRow dr in _drs)
                {
                    _miItem = new MenuItem();

                    if (dtSource.Columns.IndexOf(ItemTextColumnName) >= 0)
                    {
                        _miItem.Text = dr[ItemTextColumnName].ToString();
                    }
                    else _miItem.Text = "null";


                    if (dtSource.Columns.IndexOf(ItemValueColumnName) >= 0)
                    {
                        int.TryParse(dr[ItemValueColumnName].ToString(), out _nMenuValue);
                        _miItem.Value = _nMenuValue.ToString();
                    }

                    if (dtSource.Columns.IndexOf(ItembIsClickColumnName) >= 0)
                    {
                        bool.TryParse(dr[ItembIsClickColumnName].ToString(), out _bIsClick);

                    }

                    if (bIsClick == true && dtSource.Columns.IndexOf(NavigateUrlColumnName) >= 0)
                    {

                        _miItem.NavigateUrl = dr[NavigateUrlColumnName].ToString();
                    }


                    if (_bIsPopup)
                    {
                        _miItem.Target = "_blank";
                    }
                    //TreeView2.Items.Add(_miItem);
                    miItem.ChildItems.Add(_miItem);
                    //Menu1.Items.Add(_miItem);
                    AddChildMenu(_miItem, _nMenuValue);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
