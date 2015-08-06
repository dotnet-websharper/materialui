namespace WebSharper.MaterialUI

open WebSharper

[<AutoOpen>]
module Resources =
    
    type MaterialUI() =
        inherit Resources.BaseResource("material-ui.min.js")
