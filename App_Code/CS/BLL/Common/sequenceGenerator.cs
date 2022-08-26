using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.IO;

/// <summary>
/// Summary description for sequenceGenerator
/// </summary>
public class sequenceGenerator
{
    public sequenceGenerator()
    {
        
    }

    static string fileName = HttpContext.Current.Server.MapPath("~/sequence.xml");

    public static void writeNextSequence(int lastSequence)
    {
        XmlTextWriter writer = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);

        try
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Details");
            writer.WriteStartElement("Sequence");

            writer.WriteAttributeString("Name", "nextSequence");
            writer.WriteString((lastSequence + 10).ToString());

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        finally
        {
            writer.Close();
        }
    }

    public static int readLastSequence()
    {
        XmlDocument doc = new XmlDocument();
        int lastSequence = 0;
        try
        {
            doc.Load(fileName);
            foreach (XmlElement elements in doc.SelectNodes("Details/Sequence"))
            {
                //elements.GetAttribute("Name").ToString();
                lastSequence = int.Parse(elements.InnerText);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        finally
        {
            doc = null;
        }
        return lastSequence;
    }
}