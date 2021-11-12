// Eric Cool and Brett Bernardi
// Organization of Programming Languages 
// Project

module OPL.Project.GeneratePrimes

open System

// Function that determines if `n1` can be divided by `n2`
let isDivisible n1 n2 =
    // modulus check
    n1 % n2 = 0

// Function that will calculate and return the square root of the Integer
// argument, and return an integer value. 
let sqrttoint n =
    (int (sqrt (float n)))

// Function that determines if `number` is a prime
let isPrime number =
    // list of numbers ranging from `12` => `(number / 2) + 1`
    let max = sqrttoint number
    let range =
        // Create 2 lists of
        // - the number - ex: [ 10 ]
        // - numbers up to half the number - ex: [ 1, 2, 3, 4, 5 ]
        // and join them together - ex: [ 10, 1, 2, 3, 4, 5 ]
        [ 2 .. max ]
        // Filter the list by unique values (for #2)

    // allow count to be changed (mutable)
    let mutable count = 0

    // iterate over the list `range`
    for num in range do
        // check if `number` can be divided by `num`
        if isDivisible number num then
            // increment the counter
            count <- count + 1
    // true/false
    count = 0 // if `count == 0` then it is a prime number

// Function to generate a list of primes up to the given `number`
let generatePrimes number =
    // Filter a list from [`2` => `number`] if they are prime
    List.filter isPrime [ 2 .. number ]

// Function that will print out a list, with a new line inserted after
// every 10 elements
let printList list = 
  let mutable count = 1
  for num in list do
    printf "%5d " num
    if count % 10 = 0 then
      printf "\n"
    count <- count + 1
    


// Main Entry to the Application
[<EntryPoint>]
let main argv =
    printfn "Generate Prime Numbers\n\n"

    printf "Find prime numbers from 1 - "

    // Reads the input from the user
    let mutable max = System.Console.ReadLine()

    // Attempt to parse the user argument (max), storing it as an int
    // into number
    let mutable number = 0
    if Int32.TryParse(max, &number) then
      printfn "Find prime numbers up to: %d" number

      // Generate a list of primes and print them
      let primeList = generatePrimes number
      
      // Get size of list of primes (number of primes calculated)
      let numOfPrimes = List.length primeList
      
      // Print out list of primes
      printList primeList

      // Print out size of list of primes
      printf "\n\n\nYou generated %d of primes!\n\n\n" numOfPrimes

      0
    else 
      printfn "Error parsing input!"
      1

