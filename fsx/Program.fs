open System
open FSharp.Control
open FSharp.Control.Reactive
open FSharp.Control.Reactive.Builders

module Seq =
    let toObservable xs = xs |> Observable.toObservable 

type Grade = A | B | ``B-`` | C | D | F 

let (|Between|_|) start last (n:int) = 
    if n >= start && n <= last then Some () else None  

let calculateGrade n = 
    match n with
    | Between 90 100    -> A
    | Between 80 89     -> B
    | Between 70 79     -> ``B-``
    | Between 60 69     -> C
    | Between 50 59     -> D
    | _ -> F

let result = calculateGrade 64

let add a b = a + b

let partialFunc = add 5

let add1 x = add x 1

let times2 x = x * 2

let subtract1 x = x - 1

let add1times2 = add1 >> times2 >> subtract1

let message = result.ToString() // Call the function
printfn "Your grade is %s" message

let seqTest =
    seq {
        yield 1
        yield 2
    }

let asyncseqTest = 
    asyncSeq {
        yield 1
        let x = [1..5]
        yield! x |> AsyncSeq.ofSeq 
    }

let obs2Test = 
    observe {
        yield 1
        yield! Observable.result 6
        yield! seqTest |> Observable.toObservable
    }

let obs = 
    let timer = new Timers.Timer(100.0)
    timer.Elapsed |>
    (Observable.map <| fun x -> x.SignalTime) 