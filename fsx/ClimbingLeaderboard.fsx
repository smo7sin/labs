// https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem

module List =
    let indexOf value list =
        list |> List.findIndex (fun x -> x = value)


let rec solution ranked player =
    seq {
        match player with
        | x :: xs ->
            let newRanks =
                ranked
                |> List.append [ x ]
                |> List.distinct
                |> List.sortDescending

            let rank = (newRanks |> List.indexOf x) + 1
            yield rank
            yield! solution newRanks xs
        | [] -> ()
    }

let main () =
    do
        let ranked = [ 100; 90; 90; 80; 75; 60 ]
        let player = [ 50; 65; 77; 90; 102 ]
        let result = solution ranked player

        result |> Seq.iter (printfn "%d")
