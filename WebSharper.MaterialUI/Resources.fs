namespace WebSharper.MaterialUI

open WebSharper

[<AutoOpen>]
module Resources =
    
    type MaterialUI() =
        inherit Resources.BaseResource("WebSharper.MaterialUI.material-ui.min.js")
