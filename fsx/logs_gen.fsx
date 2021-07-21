open System.Text.Json
#r "nuget: FSharp.Data"
#r "nuget: FsRandom"

open System
open FSharp.Data
open FSharp.Data.HttpRequestHeaders
open FsRandom

module List =
    let randomize xs =  List.randomInit (List.length xs) (fun i -> random { return xs.[i]})
    let chooseRandom xs = random { 
            let! i = List.length xs |> Utility.chooseOne
            return xs.[i] 
        }

module Random =
    let state = createState systemrandom (Random ())
    let get gen = Random.get gen state
    let next gen = Random.next gen state

let getSeverity = 
    ["information"; "warning"; "error"; "debug"] 
    |> List.chooseRandom 

let createLog = {| 
        senderId = Random.get <| Utility.chooseOne 1000
        timestamp = DateTime.UtcNow
        correlationId = $"cor-{Random.get <| String.randomNumeric 3}"
        severity = Random.get getSeverity
        payload = Seq.init 5 (fun _ -> Random.get (String.randomAlphanumeric 5)) |> Seq.pairwise |> Map.ofSeq
    |}

let nums = seq {
        yield 4
        yield! [1;2]
    }
    
let response = 
    Http.RequestString("http://httpbin.org/post", 
        headers = [ ContentType HttpContentTypes.Json ],
        body = TextRequest JsonSerializer.Serialize (createLog))

let json = JsonSerializer.Serialize (createLog)
printfn "%s" json