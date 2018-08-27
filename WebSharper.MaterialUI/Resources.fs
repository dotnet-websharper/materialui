namespace WebSharper.MaterialUI

open WebSharper

[<AutoOpen>]
module Resources =

    [<Require(typeof<WebSharper.React.Bindings.Resources.ReactDOM>)>]
    type MaterialUI() =
        inherit Resources.BaseResource("https://unpkg.com/@material-ui/core/umd/material-ui.development.js")
