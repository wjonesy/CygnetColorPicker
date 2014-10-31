/*
' Copyright (c) 2014  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using Christoc.Modules.CygnetColorPicker.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using System.IO;

namespace Christoc.Modules.CygnetColorPicker
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from CygnetColorPickerModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : CygnetColorPickerModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //string pathToLessFile = "Portals/0/Skins/Cygnet/css/PortalNameColor.css";
                //Console.WriteLine(pathToLessFile.ToString());

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }






        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        protected void btnSubmitColors_Click(object sender, EventArgs e)
        {


            string pathToLessFile = "/Portals/0/Skins/Cygnet/css/PortalNameColor.less";
            string pathToCssFile = "/Portals/0/Skins/Cygnet/css/" + DotNetNuke.Entities.Portals.PortalSettings.Current.PortalName.ToString() + "Color.css";



            try
            {
                //Read less file with tokens
                using (StreamReader lessFile = new StreamReader(Server.MapPath(pathToLessFile)))
                {
                    String lessFileContents = lessFile.ReadToEnd();
                    //Label2.Text = lessFileContents.ToString();
                    //replace variable with selected colors
                    lessFileContents = lessFileContents.Replace("[background-color]", hidbackgroundcolor.Value.ToString());
                    lessFileContents = lessFileContents.Replace("[main-background-color]", hidmainbackgroundcolor.Value.ToString());
                    //lessFileContents = lessFileContents.Replace("[textColor]", hidtextColor.Value.ToString());

                    //parse less file to css 
                    string cssfile = dotless.Core.Less.Parse(lessFileContents).ToString();


                    //write css file
                    using (StreamWriter writeLessFile = new StreamWriter(Server.MapPath(pathToCssFile), false))
                    {
                        writeLessFile.WriteLine(cssfile); // Write the file.

                    }
                }


            }
            catch
            {
                Console.WriteLine("The file could not be read:");

            }
        }
    }
}