// For more information see https://aka.ms/fsharp-console-apps
open NAudio.MediaFoundation
open NAudio.Wasapi
open NAudio.Wave
open System.Threading
open System


let url = "https://ice1.somafm.com/groovesalad-128-aac"

printfn "Starting Groove Salad Playback"

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

let start () =
    use mf = new MediaFoundationReader(url)
    use wo = new WasapiOut()

    init wo mf
    play wo
    
    printfn "Press any key to stop"
    Console.ReadKey() |> ignore

start()


