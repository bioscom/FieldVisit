using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;

public partial class App_IDD_UserControl_oHistoricalData : System.Web.UI.UserControl
{
    EIdd.CategoryMgt cat = new EIdd.CategoryMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    LoadRootNodes(RadTreeView1, TreeNodeExpandMode.ServerSideCallBack);
        //}
    }

    protected void Page_Init(object sender, EventArgs e)
    {
            LoadRootNodes(RadTreeView1, TreeNodeExpandMode.ServerSideCallBack);
    }

    private void LoadRootNodes(RadTreeView treeView, TreeNodeExpandMode expandMode)
    {
        DataTable data = cat.GetServices(); // GetData(new SqlCommand("SELECT * FROM ProductCategories WHERE ParentId IS NULL"));

        foreach (DataRow row in data.Rows)
        {
            var node = new RadTreeNode();
            node.Text = row["CATEGORY"].ToString();
            node.Value = row["CATEGORYID"].ToString();
            node.ExpandMode = expandMode;
            treeView.Nodes.Add(node);
        }
    }

    protected void RadTreeView1_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        PopulateNodeOnDemand(e, TreeNodeExpandMode.ServerSideCallBack);
    }

    private void PopulateNodeOnDemand(RadTreeNodeEventArgs e, TreeNodeExpandMode expandMode)
    {
        DataTable data = cat.GetChildNodes(e.Node.Value);

        foreach (DataRow row in data.Rows)
        {
            RadTreeNode node = new RadTreeNode();
            node.Text = row["VENDOURCODE"].ToString();
            node.Value = row["REQUESTID"].ToString();
            //if (Convert.ToInt32(row["ChildrenCount"]) > 0)
            //{
            //    node.ExpandMode = expandMode;
            //}
            node.ExpandMode = expandMode;
            e.Node.Nodes.Add(node);
        }
        e.Node.Expanded = true;
    }

    private void UpdateLoadingStatusPosition(TreeViewLoadingStatusPosition statusPosition)
    {
        RadTreeView1.LoadingStatusPosition = statusPosition;
    }

    //[WebMethod]
    //public static RadTreeNodeData[] GetProducts(RadTreeNodeData node)
    //{
    //    DataTable data = GetChildNodes(node.Value);
    //    List<RadTreeNodeData> result = new List<RadTreeNodeData>();

    //    foreach (DataRow row in data.Rows)
    //    {
    //        RadTreeNodeData childNode = new RadTreeNodeData();
    //        childNode.Text = row["Title"].ToString();
    //        childNode.Value = row["CategoryId"].ToString();
    //        if (Convert.ToInt32(row["ChildrenCount"]) > 0)
    //        {
    //            childNode.ExpandMode = TreeNodeExpandMode.WebService;
    //        }
    //        result.Add(childNode);
    //    }
    //    return result.ToArray();
    //}
}