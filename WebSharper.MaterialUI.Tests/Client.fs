namespace WebSharper.MaterialUI.Tests

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings
open WebSharper.React
open WebSharper.React.Html
open WebSharper.MaterialUI
module MUI = WebSharper.MaterialUI.Components

[<JavaScript>]
module Client =

    // let x = React.Make AppBar (AppBar.Config(Color = Color.Primary))

    type Task =
        {
            Name  : string
            State : bool
        }

        static member Toggle task _ =
            { task with
                State = not task.State }

    type State =
        {
            Input : string
            Tasks : Task list
        }

        static member Default =
            {
                Input = ""
                Tasks =
                    [
                        { Name = "buy milk"; State = false }
                    ]
            }

    type Main(props) as this =
        inherit React.Component<Styles, State>(props)

        do this.SetInitialState State.Default

        let classes = this.Props.classes

        // TODO: theme
        override this.Render() =
            MUI.Grid [
                attr.className classes.root
                "container" => true
                "direction" => "column"
            ] [
                MUI.Grid [
                    "item" => true
                    "container" => true
                ] [
                    MUI.Grid ["item" => true; "xs" => 9] [
                        MUI.TextField [
                            "fullWidth" => true
                            attr.value this.State.Input
                            attr.placeholder "What needs to be done?"
                            on.change (fun (ev: SyntheticEvent) ->
                                this.SetState { this.State with Input = ev.Target?value })
                        ] []
                    ]
                    MUI.Grid ["item" => true; "xs" => 3] [
                        MUI.Button [
                            on.click (fun _ ->
                                if this.State.Input.Length > 0 && not (List.exists (fun task -> task.Name = this.State.Input) this.State.Tasks) then
                                    { this.State with
                                        Input = ""
                                        Tasks =
                                            { Name = this.State.Input; State = false } :: this.State.Tasks }
                                    |> this.SetState)
                        ] [text "Add"]
                    ]
                ]
                MUI.Grid ["item" => true] [
                    MUI.Button [
                        on.click (fun _ ->
                            { this.State with
                                Tasks =
                                    this.State.Tasks
                                    |> List.filter (fun task -> not task.State) }
                            |> this.SetState)
                    ] [text "Clear completed tasks"]
                ]
                MUI.Grid ["item" => true] [
                    MUI.List ["subheader" => MUI.ListSubheader [] [text "My tasks"]] (
                        this.State.Tasks
                        |> List.map (fun task ->
                            MUI.ListItem [
                                "button" => true
                                attr.className classes.listItem
                                on.click (fun _ ->
                                    { this.State with
                                        Tasks =
                                            this.State.Tasks
                                            |> List.map (fun x ->
                                                if x.Name = task.Name then
                                                    { task with State = not task.State }
                                                else
                                                    x
                                            ) }
                                    |> this.SetState)
                            ] [
                                MUI.Checkbox ["checked" => task.State] []
                                MUI.ListItemText [] [text task.Name]
                            ]
                        )
                    )
                ]
            ]

    [<SPAEntryPoint>]
    let Main() =
        // MaterialUI.Context.ThemeManager.SetTheme Theme.Dark

        MaterialUI.WithStyles (fun theme -> New [
            "root" => New [
                // "width" => "100%"
                // "maxWidth" => 360
                // "backgroundColor" => theme?palette?background?paper
            ]
        ]) Main
        |> React.Mount JS.Document.Body
