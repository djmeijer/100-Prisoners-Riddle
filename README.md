# 100 Prisoners Riddle

- After seeing this item on Veritasium's channel: [The Riddle That Seems Impossible Even If You Know The Answer](https://www.youtube.com/watch?v=iSNsgj1OCLA).
- The actual theoritical probability never get's worse than 1 - ln 2 ≈ 30,7% for any number of prisoners where intuition might point to extremely small, near zero probability.
- When the first prisoner is allowed to do an exchange of slips between two boxes and the right strategy is choosen, the survival rate is 100%! 🤯

I did a test run with:
- 3 group strategies
    1. Cheating strategy. Each prisoner opens all boxes for a 100% success rate. This is just a sanity check for the algorithm and can't be used as a solution.
    2. First closed box. Each prisoner just opens the first closed box. This is a random strategy and not successful.
    3. Circle strategy. This is the winning strategy.
- 3 different prisoner group size: 20, 100, 200. This is to test scaling.
- 3 different first prisoner strategies
    1. Don't use the option two exchange slips.
    2. Perform a random exchange.
    3. Break longest circle in two. This is the winning first prisoner strategy.
- Repeat each of the above combinations 20.000 times.

| Iterations | Number of prisoners | Group strategy                           | First person strategy               | Found survival probability | Theoretical probability | Time to compute (ms) |
|------------|---------------------|------------------------------------------|-------------------------------------|----------------------------|-------------------------|----------------------|
| 20.000     | 20                  | Best strategy: follow the slips          | Break the longest circle            | 100,00%                    | 100,00%                 | 1.740                |
| 20.000     | 20                  | Best strategy: follow the slips          | Do nothing                          | 33,37%                     | 33,12%                  | 1.462                |
| 20.000     | 20                  | Best strategy: follow the slips          | Open 2 random boxes, exchange slips | 33,27%                     | 33,12%                  | 1.662                |
| 20.000     | 20                  | Cheating strategy: open all boxes        | Break the longest circle            | 100,00%                    | 100,00%                 | 2.153                |
| 20.000     | 20                  | Cheating strategy: open all boxes        | Do nothing                          | 100,00%                    | 33,12%                  | 1.758                |
| 20.000     | 20                  | Cheating strategy: open all boxes        | Open 2 random boxes, exchange slips | 100,00%                    | 33,12%                  | 1.992                |
| 20.000     | 20                  | First closed: open the first box you see | Break the longest circle            | 0,00%                      | 100,00%                 | 2.406                |
| 20.000     | 20                  | First closed: open the first box you see | Do nothing                          | 0,00%                      | 33,12%                  | 1.918                |
| 20.000     | 20                  | First closed: open the first box you see | Open 2 random boxes, exchange slips | 0,01%                      | 33,12%                  | 2.140                |
| 20.000     | 100                 | Best strategy: follow the slips          | Break the longest circle            | 100,00%                    | 100,00%                 | 59.915               |
| 20.000     | 100                 | Best strategy: follow the slips          | Do nothing                          | 31,17%                     | 31,18%                  | 55.573               |
| 20.000     | 100                 | Best strategy: follow the slips          | Open 2 random boxes, exchange slips | 31,58%                     | 31,18%                  | 49.168               |
| 20.000     | 100                 | Cheating strategy: open all boxes        | Break the longest circle            | 100,00%                    | 100,00%                 | 44.722               |
| 20.000     | 100                 | Cheating strategy: open all boxes        | Do nothing                          | 100,00%                    | 31,18%                  | 39.140               |
| 20.000     | 100                 | Cheating strategy: open all boxes        | Open 2 random boxes, exchange slips | 100,00%                    | 31,18%                  | 40.750               |
| 20.000     | 100                 | First closed: open the first box you see | Break the longest circle            | 0,00%                      | 100,00%                 | 67.180               |
| 20.000     | 100                 | First closed: open the first box you see | Do nothing                          | 0,00%                      | 31,18%                  | 63.713               |
| 20.000     | 100                 | First closed: open the first box you see | Open 2 random boxes, exchange slips | 0,00%                      | 31,18%                  | 60.594               |
| 20.000     | 200                 | Best strategy: follow the slips          | Break the longest circle            | 100,00%                    | 100,00%                 | 101.686              |
| 20.000     | 200                 | Best strategy: follow the slips          | Do nothing                          | 31,09%                     | 30,93%                  | 108.978              |
| 20.000     | 200                 | Best strategy: follow the slips          | Open 2 random boxes, exchange slips | 30,78%                     | 30,93%                  | 108.041              |
| 20.000     | 200                 | Cheating strategy: open all boxes        | Break the longest circle            | 100,00%                    | 100,00%                 | 70.686               |
| 20.000     | 200                 | Cheating strategy: open all boxes        | Do nothing                          | 100,00%                    | 30,93%                  | 63.528               |
| 20.000     | 200                 | Cheating strategy: open all boxes        | Open 2 random boxes, exchange slips | 100,00%                    | 30,93%                  | 59.545               |
| 20.000     | 200                 | First closed: open the first box you see | Break the longest circle            | 0,00%                      | 100,00%                 | 112.160              |
| 20.000     | 200                 | First closed: open the first box you see | Do nothing                          | 0,00%                      | 30,93%                  | 112.458              |
| 20.000     | 200                 | First closed: open the first box you see | Open 2 random boxes, exchange slips | 0,00%                      | 30,93%                  | 111.051              |

Took 126.275 ms in total to compute all runs.
