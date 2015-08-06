namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React

[<Require(typeof<MaterialUI>)>]
[<JavaScript>]
module MaterialUI =
    
    type ThemeManager [<Inline "new MaterialUI.Styles.ThemeManager()">] () =
        
        [<Inline "$0.getCurrentTheme()">]
        member this.GetCurrentTheme () = X<ThemeManager>

    type Context =
        {
            [<Name "muiTheme">] MuiTheme : ThemeManager
        }

        interface GenericContext

    let Context =
        {
            MuiTheme = ThemeManager().GetCurrentTheme()
        }
