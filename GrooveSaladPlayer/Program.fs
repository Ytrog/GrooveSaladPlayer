// For more information see https://aka.ms/fsharp-console-apps
open NAudio.MediaFoundation
open NAudio.Wasapi
open NAudio.Wave
open System.Threading
open System


let url = "https://ice1.somafm.com/groovesalad-128-aac"

printfn "Starting Groove Salad Playback"

let waitpos (wo : WasapiOut) pos =
    while wo.GetPosition() < pos do
        Thread.Sleep 1000

let position (wo : WasapiOut) = 
    wo.GetPosition() |> printfn "%i"

let init (wo: WasapiOut) mf = 
    try
        wo.Init(mf)
    with
        | e -> 
            printfn "%s" e.Message
            reraise()

let play (wo : WasapiOut) = 
    try
        wo.Play()
    with
        | e -> 
            printfn "%s" e.Message
            reraise()


let rec catchkey (action : string) (k : ConsoleKey) = 
    printfn "Press %O to %s" k action
    let key = Console.ReadKey()
    match key.Key with
    | x when x = k  -> ()
    | _ -> catchkey action k

let start () =
    use mf = new MediaFoundationReader(url)
    use wo = new WasapiOut()

    init wo mf
    play wo
    
    waitpos wo 1000 // wait for it to actually play audibly

    printfn "Playing"

    catchkey "stop" ConsoleKey.Escape

start()


