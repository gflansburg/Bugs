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
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using System;
using System.Text;

namespace Gafware.Modules.Bugs
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from BugsModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : BugsModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadHeader();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public void LoadHeader()
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("ComponentScriptBugs"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ComponentScriptBugs", string.Format("<script language=\"javascript\" type=\"text/javascript\" src=\"{0}\"></script>", string.Concat(base.ControlPath, "BugsJS.ashx")), false);
                StringBuilder stringBuilder = new StringBuilder();
                if (base.HasBugs)
                {
                    stringBuilder.AppendLine(string.Format("new BugController({{'minBugs':{0}, 'maxBugs':{1}, 'mouseOver':'{2}'}});", base.MinBugs, base.MaxBugs, base.MouseOver));
                }
                if (base.HasSpiders)
                {
                    stringBuilder.AppendLine(string.Format("new SpiderController({{'minBugs':{0}, 'maxBugs':{1}, 'mouseOver':'{2}'}});", base.MinSpiders, base.MaxSpiders, base.MouseOver));
                }
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ComponentScriptBugsInit", stringBuilder.ToString(), true);
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                return new ModuleActionCollection();
            }
        }
    }
}