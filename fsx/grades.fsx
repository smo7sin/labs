
let nextMultiple x = 
    let m = x % 5
    if m > 0 then x - m + 5 else x

let selectGrade (x,y) = if y - x < 3 then y else x

let gradingStudents grades = 
    grades |>
    Seq.map ((fun x -> (x, nextMultiple x)) >> selectGrade) 

let results = gradingStudents [73;67;38;33]

results |> Seq.iter (printfn "%d")
