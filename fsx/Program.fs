open System

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

let message = result.ToString() // Call the function
printfn "Your grade is %s" message