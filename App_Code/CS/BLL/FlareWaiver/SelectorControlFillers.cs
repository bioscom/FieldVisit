using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for SelectorControlFillers
/// </summary>
public static class SelectorControlFillers
{
	static SelectorControlFillers()
	{
		
	}

    public static bool FillDBL(DropDownList theDropDownList, DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {
            string listItemText = dr[0].ToString();
            string listItemValue = dr[1].ToString();
            theDropDownList.Items.Add(new ListItem(listItemText, listItemValue));
        }

        return true;
    }

    public static bool FillDBLByValue(DropDownList theDropDownList, string listItemValue, string listItemText)
    {
        theDropDownList.Items.Clear();
        theDropDownList.Items.Add(new ListItem(listItemText, listItemValue));

        return true;
    }

    public static bool FillDBLByValue2(DropDownList theDropDownList, string listItemValue, string listItemText)
    {
        theDropDownList.Items.Add(new ListItem(listItemText, listItemValue));

        return true;
    }

    public static bool FillDBLSpecial(DropDownList theDropDownList, DataTable dt)
    {
        theDropDownList.Items.Add(new ListItem("None", "None"));

        foreach (DataRow dr in dt.Rows)
        {
            string listItemText = dr[0].ToString();
            string listItemValue = dr[1].ToString();
            theDropDownList.Items.Add(new ListItem(listItemText, listItemValue));
        }

        return true;
    }

    public static bool FillListBox(ListBox theListBox, DataTable dt, string ItemValue, string ItemText)
    {
        theListBox.Items.Clear();
        theListBox.Items.Add(new ListItem(ItemValue, ItemText));

        foreach (DataRow dr in dt.Rows)
        {
            string listItemText = dr[0].ToString();
            string listItemValue = dr[1].ToString();
            theListBox.Items.Add(new ListItem(listItemText, listItemValue));
        }

        return true;
    }
}