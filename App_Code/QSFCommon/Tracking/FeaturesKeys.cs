using System;
using System.Linq;


public static class FeaturesKeys
{
    public static string Dot = ".";

    public static class Context 
    {
        public static string Navigation = "Navigation";
        public static string Demos = "Demos";
        public static string Application = "Application";
        public static string Skins = "Skins";
    }

    public static class Feature
    {
        public static string Comment = "Comment";
        public static string Rating = "Rating";
    }

    public static string FormatFeature(string feature, string name)
    {
        return feature + FeaturesKeys.Dot + name;
    }

    public static string FormatFeature(string feature, string controlName, string demoName)
    {
        return string.Format("{0}.{1}.{2}", feature, controlName, demoName);
    }
    
}