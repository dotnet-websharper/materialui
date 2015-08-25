namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React

[<JavaScript>]
type Theme =
    static member Light = As<Theme> "LIGHT"
    static member Dark  = As<Theme> "DARK"

[<JavaScript>]
type ThemeManager [<Inline "new MaterialUI.Styles.ThemeManager()">] () =
        
    [<Inline "$0.getCurrentTheme()">]
    member this.GetCurrentTheme () = X<ThemeManager>

    [<Inline "$0.setTheme($0.types[$1])">]
    member this.SetTheme (_ : Theme) = ()

[<Require(typeof<MaterialUI>)>]
[<JavaScript>]
module MaterialUI =
    
    type Context =
        {
            [<Name "muiTheme">] ThemeManager : ThemeManager
        }

        interface GenericContext

    let Context =
        {
            ThemeManager = ThemeManager().GetCurrentTheme()
        }

[<assembly: System.Web.UI.WebResource("material-ui.min.js", "text/javascript")>]
do ()
