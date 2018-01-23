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

[<JavaScript>]
module MaterialUI =
    
    type Context =
        {
            [<Name "muiTheme">] ThemeManager : ThemeManager
        }

        interface React.Context

    let Context =
        {
            ThemeManager = ThemeManager().GetCurrentTheme()
        }

[<JavaScript>]
module Events =
    
    let OnChange callback (component' : TextField) =
        component'.Events <- [ ("onChange", callback) ]
        component'

    let OnClick callback (component' : RaisedButton) =
        component'.Events <- [ ("onClick", callback) ]
        component'

    let OnCheck callback (component' : Checkbox) =
        component'.Events <- [ ("onCheck", callback) ]
        component'

[<assembly: Require(typeof<MaterialUI>)>]
[<assembly: WebResource("WebSharper.MaterialUI.material-ui.min.js", "text/javascript")>]
do ()
