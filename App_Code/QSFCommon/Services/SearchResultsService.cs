using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Telerik.Web.UI;
using System.Xml;
using System.Web.Caching;
using Telerik.QuickStart;
using System.Web.SessionState;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class SearchResultsService
{
    protected HttpSessionState Session
    {
        get
        {
            return HttpContext.Current.Session;
        }
    }

    protected string CurrentLanguage
    {
        get
        {
            return (string)(Session[QSFConstants.NavigationLanguageLiteral] ?? "CS");
        }
    }

    [OperationContract]
    public SearchBoxItemData[] GetSearchResults(SearchBoxContext context)
    {
        List<SearchBoxItemData> resultSet = new List<SearchBoxItemData>();
        List<XmlNode> exampleList = ExamplesProvider.Instance.SearchableExamples;
        string searchString = context.Text;

        if (string.IsNullOrEmpty(searchString.Trim()))
            return resultSet.ToArray();

        foreach (string token in searchString.Split(' '))
        {
            string criteria = token.Trim().ToUpper();
            if (string.IsNullOrEmpty(criteria))
                continue;
            resultSet.Clear();

            exampleList = exampleList.FindAll(node =>
            {
                XmlNode productNode = FindProductElement(node);
                string product = productNode.Attributes["text"].Value;
                string text = node.Attributes["name"].Value;

                bool hasResult = product.ToUpperInvariant().Contains(criteria) ||
                        text.ToUpperInvariant().Contains(criteria);

                if (hasResult)
                {
                    string url = string.Format("{0}/{1}/default{2}.aspx",
                                            HttpContext.Current.Request.ApplicationPath,
                                            node.Attributes["path"].Value.ToLower(),
                                            CurrentLanguage.ToLower());

                    if (node.Attributes["product"] != null)
                        url += "?product=" + node.Attributes["product"].Value;

                    SearchBoxItemData item = new SearchBoxItemData();
                    item.Text = product;
                    item.Value = url;
                    item.DataItem["Text"] = text;

                    if (!resultSet.Contains(item))
                        resultSet.Add(item);
                }

                return hasResult;
            });
        }

        return resultSet.ToArray();
    }

    //Find whether this demo is contained in another's control demos directory
    private XmlNode FindProductElement(XmlNode exampleElement)
    {
        XmlNode result = exampleElement;
        while (result.Attributes["productId"] == null && result != exampleElement.OwnerDocument.DocumentElement)
        {
            result = result.ParentNode;
        }

        return result;
    }
}
