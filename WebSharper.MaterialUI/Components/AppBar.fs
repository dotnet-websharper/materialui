namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type AppBar(title, ?depth) =
    [<Inline "MaterialUI.AppBar">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    "title"  => title
                    "zDepth" => default' depth 1
                ])
