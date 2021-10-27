/*
' Copyright (c) 2021  Gafware
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using System;

namespace Gafware.Modules.Bugs
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from BugsSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : BugsModuleSettingsBase
    {
        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        protected void chkBugs_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlBugs.Visible = this.chkBugs.Checked;
        }

        protected void chkSpiders_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlSpiders.Visible = this.chkSpiders.Checked;
        }

        private void DeleteSettings(ModuleController modules)
        {
            try
            {
                modules.DeleteTabModuleSetting(base.TabModuleId, "BUGS");
                modules.DeleteTabModuleSetting(base.TabModuleId, "SPIDERS");
                modules.DeleteTabModuleSetting(base.TabModuleId, "MINBUGS");
                modules.DeleteTabModuleSetting(base.TabModuleId, "MAXBUGS");
                modules.DeleteTabModuleSetting(base.TabModuleId, "MINSPIDERS");
                modules.DeleteTabModuleSetting(base.TabModuleId, "MAXSPIDERS");
                modules.DeleteTabModuleSetting(base.TabModuleId, "MOUSEOVER");
                modules.DeleteModuleSetting(base.ModuleId, "BUGS");
                modules.DeleteModuleSetting(base.ModuleId, "SPIDERS");
                modules.DeleteModuleSetting(base.ModuleId, "MINBUGS");
                modules.DeleteModuleSetting(base.ModuleId, "MAXBUGS");
                modules.DeleteModuleSetting(base.ModuleId, "MINSPIDERS");
                modules.DeleteModuleSetting(base.ModuleId, "MAXSPIDERS");
                modules.DeleteModuleSetting(base.ModuleId, "MOUSEOVER");
            }
            catch (Exception exception)
            {
                Exceptions.ProcessModuleLoadException(this, exception);
            }
        }

        public override void LoadSettings()
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    this.txtMinBugs.Value = new double?((double)base.MinBugs);
                    this.txtMaxBugs.Value = new double?((double)base.MaxBugs);
                    this.txtMinSpiders.Value = new double?((double)base.MinSpiders);
                    this.txtMaxSpiders.Value = new double?((double)base.MaxSpiders);
                    this.lstMouseOver.SelectedValue = base.MouseOver;
                    this.chkBugs.Checked = base.HasBugs;
                    this.chkSpiders.Checked = base.HasSpiders;
                    this.pnlBugs.Visible = base.HasBugs;
                    this.pnlSpiders.Visible = base.HasSpiders;
                }
            }
            catch (Exception exception)
            {
                Exceptions.ProcessModuleLoadException(this, exception);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                ModuleController moduleController = new ModuleController();
                bool flag = true;
                if (base.Settings.Contains("SETTINGS_GLOBAL"))
                {
                    flag = Convert.ToBoolean(base.Settings["SETTINGS_GLOBAL"].ToString());
                }
                if (flag != this.chkModuleSettings.Checked)
                {
                    this.DeleteSettings(moduleController);
                    if (this.chkModuleSettings.Checked)
                    {
                        foreach (ModuleInfo allTabsModulesByModuleID in moduleController.GetAllTabsModulesByModuleID(base.ModuleId))
                        {
                            moduleController.DeleteTabModuleSetting(allTabsModulesByModuleID.TabModuleID, "BUGS");
                            moduleController.DeleteTabModuleSetting(allTabsModulesByModuleID.TabModuleID, "SPIDERS");
                            moduleController.DeleteTabModuleSetting(allTabsModulesByModuleID.TabModuleID, "MINBUGS");
                            moduleController.DeleteTabModuleSetting(allTabsModulesByModuleID.TabModuleID, "MAXBUGS");
                            moduleController.DeleteTabModuleSetting(allTabsModulesByModuleID.TabModuleID, "MINSPIDERS");
                            moduleController.DeleteTabModuleSetting(allTabsModulesByModuleID.TabModuleID, "MAXSPIDERS");
                            moduleController.DeleteTabModuleSetting(allTabsModulesByModuleID.TabModuleID, "MOUSEOVER");
                        }
                    }
                }
                int moduleId = base.ModuleId;
                bool @checked = this.chkModuleSettings.Checked;
                moduleController.UpdateModuleSetting(moduleId, "SETTINGS_GLOBAL", @checked.ToString());
                if (!this.chkModuleSettings.Checked)
                {
                    int tabModuleId = base.TabModuleId;
                    bool checked1 = this.chkBugs.Checked;
                    moduleController.UpdateTabModuleSetting(tabModuleId, "BUGS", checked1.ToString());
                    int num = base.TabModuleId;
                    bool flag1 = this.chkSpiders.Checked;
                    moduleController.UpdateTabModuleSetting(num, "SPIDERS", flag1.ToString());
                    int tabModuleId1 = base.TabModuleId;
                    double? value = this.txtMinBugs.Value;
                    moduleController.UpdateTabModuleSetting(tabModuleId1, "MINBUGS", value.ToString());
                    int num1 = base.TabModuleId;
                    double? nullable = this.txtMaxBugs.Value;
                    moduleController.UpdateTabModuleSetting(num1, "MAXBUGS", nullable.ToString());
                    int tabModuleId2 = base.TabModuleId;
                    double? value1 = this.txtMinSpiders.Value;
                    moduleController.UpdateTabModuleSetting(tabModuleId2, "MINSPIDERS", value1.ToString());
                    int num2 = base.TabModuleId;
                    double? nullable1 = this.txtMaxSpiders.Value;
                    moduleController.UpdateTabModuleSetting(num2, "MAXSPIDERS", nullable1.ToString());
                    moduleController.UpdateTabModuleSetting(base.TabModuleId, "MOUSEOVER", this.lstMouseOver.SelectedValue);
                }
                else
                {
                    int moduleId1 = base.ModuleId;
                    bool checked2 = this.chkBugs.Checked;
                    moduleController.UpdateModuleSetting(moduleId1, "BUGS", checked2.ToString());
                    int moduleId2 = base.ModuleId;
                    bool flag2 = this.chkSpiders.Checked;
                    moduleController.UpdateModuleSetting(moduleId2, "SPIDERS", flag2.ToString());
                    int moduleId3 = base.ModuleId;
                    double? value2 = this.txtMinBugs.Value;
                    moduleController.UpdateModuleSetting(moduleId3, "MINBUGS", value2.ToString());
                    int num3 = base.ModuleId;
                    double? nullable2 = this.txtMaxBugs.Value;
                    moduleController.UpdateModuleSetting(num3, "MAXBUGS", nullable2.ToString());
                    int moduleId4 = base.ModuleId;
                    double? value3 = this.txtMinSpiders.Value;
                    moduleController.UpdateModuleSetting(moduleId4, "MINSPIDERS", value3.ToString());
                    int num4 = base.ModuleId;
                    double? nullable3 = this.txtMaxSpiders.Value;
                    moduleController.UpdateModuleSetting(num4, "MAXSPIDERS", nullable3.ToString());
                    moduleController.UpdateModuleSetting(base.ModuleId, "MOUSEOVER", this.lstMouseOver.SelectedValue);
                }
            }
            catch (Exception exception)
            {
                Exceptions.ProcessModuleLoadException(this, exception);
            }
        }

        #endregion
    }
}