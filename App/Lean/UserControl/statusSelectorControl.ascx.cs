using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_statusSelectorControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control()
    {

    }

    public string SelectedStatus
    {
        get
        {
            return statusDrp.SelectedValue;
        }
    }

    public DropDownList ddlSelector
    {
        get
        {
            return statusDrp;
        }
    }

    public void _SelectedValue(int iSelectedValue)
    {
        statusDrp.SelectedValue = iSelectedValue.ToString();
    }

    public bool EliminateCanBeImplemented(int iKickOffMeetingHeld, int iProjectCharterCompleted, int iProcessWalk, int iVsm, int iPlanInPlace, int iKaizenEvent, int iRecommSignedOff)
    {
        //The followings must have been completed before implement could be YES
        //Identify Processes

        //Kick off meeting held (int)ProjectStatus.ProjStatus.Yes20
        //Project Charter Completed (int)ProjectStatus.ProjStatus.Yes20
        //Process Walk (int)ProjectStatus.ProjStatus.Yes20
        //VSM (int)ProjectStatus.ProjStatus.Yes40

        //Eliminate Processes

        //Plan In Place (int)ProjectStatus.ProjStatus.Yes20
        //Kaizen Event  (int)ProjectStatus.ProjStatus.Yes40
        //Recommendation Signed off (int)ProjectStatus.ProjStatus.Yes20

        bool done = false;

        if ((iKickOffMeetingHeld == (int)ProjectStatus.ProjStatus.Yes20 - 1)
            && (iProjectCharterCompleted == (int)ProjectStatus.ProjStatus.Yes20 - 1)
            && (iProcessWalk == (int)ProjectStatus.ProjStatus.Yes20 - 1)
            && (iVsm == (int)ProjectStatus.ProjStatus.Yes40)

            && (iPlanInPlace == (int)ProjectStatus.ProjStatus.Yes20 - 1)
            && (iKaizenEvent == (int)ProjectStatus.ProjStatus.Yes40)
            && (iRecommSignedOff == (int)ProjectStatus.ProjStatus.Yes20))
        {
            done = true;
        }
        return done;
    }

    public bool BeginEliminate(int iKickOffMeetingHeld, int iProjectCharterCompleted, int iProcessWalk, int iVsm)
    {
        bool done = false;

        if (((iKickOffMeetingHeld == (int)ProjectStatus.ProjStatus.Yes20 - 1) || ((iKickOffMeetingHeld == (int)ProjectStatus.ProjStatus.Ongoing10)))
            && ((iProjectCharterCompleted == (int)ProjectStatus.ProjStatus.Yes20 - 1) || ((iProjectCharterCompleted == (int)ProjectStatus.ProjStatus.Ongoing10)))
            && ((iProcessWalk == (int)ProjectStatus.ProjStatus.Yes20 - 1) || ((iProcessWalk == (int)ProjectStatus.ProjStatus.Ongoing10)))
            && ((iVsm == (int)ProjectStatus.ProjStatus.Yes40)) || ((iVsm == (int)ProjectStatus.ProjStatus.Ongoing20)))
        {
            done = true;
        }
        return done;
    }
    public bool BeginSustain(int iImplement)
    {
        bool done = false;
        if (((iImplement == (int)ProjectStatus.ProjStatus.Yes20 - 1) || ((iImplement == (int)ProjectStatus.ProjStatus.Ongoing10))))
        {
            done = true;
        }
        return done;
    }
}
