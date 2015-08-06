namespace WebSharper.React.Tests

open WebSharper
open WebSharper.JavaScript

open WebSharper.React

open WebSharper.MaterialUI

[<JavaScript>]
module Client =
    
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
    
    let Button label =
        RaisedButton(label, wide = true) -< [
            "secondary", true
        ]

    let Main =
        React.Class State.Default
        <| fun this ->
            Element.Wrap [
                Element.Wrap [
                    TextField("What needs to be done?", this.State.Input, true)
                    |>! Change (fun event ->
                        { this.State with
                            Input = event?target?value }
                        |> this.SetState
                    )

                    Button "Add"
                    |>! Click (fun _ ->
                        if this.State.Input.Length > 0 && not (List.exists (fun task -> task.Name = this.State.Input) this.State.Tasks) then
                            { this.State with
                                Input = ""
                                Tasks =
                                    { Name = this.State.Input; State = false } :: this.State.Tasks }
                            |> this.SetState
                    )
                ]
                Button "Clear completed tasks"
                |>! Click (fun _ ->
                    { this.State with
                        Tasks =
                            this.State.Tasks
                            |> List.filter (fun task -> not task.State) }
                    |> this.SetState
                )

                List("My tasks", 
                    this.State.Tasks
                    |> List.map (fun task ->
                        ListItem task.Name
                        |> ListItem.WithCheckbox task.State (fun _ ->
                            { this.State with
                                Tasks =
                                    this.State.Tasks
                                    |> List.map (fun x ->
                                        if x.Name = task.Name then
                                            { task with
                                                State = not task.State }
                                        else
                                            x
                                    ) }
                            |> this.SetState
                        )
                        :> _
                    ))
            ]
        |> Class.WithContext MaterialUI.Context
        |> React.Mount Document.Body
