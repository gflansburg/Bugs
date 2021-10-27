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
using System;

namespace Gafware.Modules.Bugs
{
    public class BugsModuleBase : PortalModuleBase
    {
        public const string CSS_TAG_INCLUDE_FORMAT = "<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\" />";

        public const string SCRIPT_TAG_INCLUDE_FORMAT = "<script language=\"javascript\" type=\"text/javascript\" src=\"{0}\"></script>";

        protected bool HasBugs
        {
            get
            {
                if (!base.Settings.Contains("BUGS"))
                {
                    return false;
                }
                return Convert.ToBoolean(base.Settings["BUGS"].ToString());
            }
        }

        protected bool HasSpiders
        {
            get
            {
                if (!base.Settings.Contains("SPIDERS"))
                {
                    return false;
                }
                return Convert.ToBoolean(base.Settings["SPIDERS"].ToString());
            }
        }

        protected int MaxBugs
        {
            get
            {
                if (!base.Settings.Contains("MAXBUGS"))
                {
                    return 20;
                }
                return Convert.ToInt32(base.Settings["MAXBUGS"].ToString());
            }
        }

        protected int MaxSpiders
        {
            get
            {
                if (!base.Settings.Contains("MAXSPIDERS"))
                {
                    return 10;
                }
                return Convert.ToInt32(base.Settings["MAXSPIDERS"].ToString());
            }
        }

        protected int MinBugs
        {
            get
            {
                if (!base.Settings.Contains("MINBUGS"))
                {
                    return 2;
                }
                return Convert.ToInt32(base.Settings["MINBUGS"].ToString());
            }
        }

        protected int MinSpiders
        {
            get
            {
                if (!base.Settings.Contains("MINSPIDERS"))
                {
                    return 3;
                }
                return Convert.ToInt32(base.Settings["MINSPIDERS"].ToString());
            }
        }

        protected string MouseOver
        {
            get
            {
                if (!base.Settings.Contains("MOUSEOVER"))
                {
                    return "nothing";
                }
                return base.Settings["MOUSEOVER"].ToString();
            }
        }

    }
}