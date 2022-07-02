# 100 Prisoners Riddle

- After seeing this: https://www.youtube.com/watch?v=iSNsgj1OCLA
- Probability reaches 1 - ln 2
- After first prisoner exchanges the flips of two boxes, after seeing all the bloxes and flips, survival rate is 100%!


| Iterations | Number of prisoners | Group strategy                           | First person strategy    | Found survival probability | Theoretical probability | Time to compute (ms) |
|------------|---------------------|------------------------------------------|--------------------------|----------------------------|-------------------------|----------------------|
| 20000      | 20                  | Best strategy: follow the slips          | Break the longest circle | 100.00 %                   | 100.00 %                | 2119                 |
| 20000      | 20                  | Best strategy: follow the slips          | Do nothing               | 33.36 %                    | 33.12 %                 | 1937                 |
| 20000      | 20                  | Cheating strategy: open all boxes        | Break the longest circle | 100.00 %                   | 100.00 %                | 1960                 |
| 20000      | 20                  | Cheating strategy: open all boxes        | Do nothing               | 100.00 %                   | 33.12 %                 | 1645                 |
| 20000      | 20                  | First closed: open the first box you see | Break the longest circle | 0.00 %                     | 100.00 %                | 1797                 |
| 20000      | 20                  | First closed: open the first box you see | Do nothing               | 0.00 %                     | 33.12 %                 | 1396                 |
| 20000      | 100                 | Best strategy: follow the slips          | Break the longest circle | 100.00 %                   | 100.00 %                | 43878                |
| 20000      | 100                 | Best strategy: follow the slips          | Do nothing               | 31.24 %                    | 31.18 %                 | 46670                |
| 20000      | 100                 | Cheating strategy: open all boxes        | Break the longest circle | 100.00 %                   | 100.00 %                | 32062                |
| 20000      | 100                 | Cheating strategy: open all boxes        | Do nothing               | 100.00 %                   | 31.18 %                 | 25508                |
| 20000      | 100                 | First closed: open the first box you see | Break the longest circle | 0.00 %                     | 100.00 %                | 36244                |
| 20000      | 100                 | First closed: open the first box you see | Do nothing               | 0.00 %                     | 31.18 %                 | 32559                |
| 20000      | 200                 | Best strategy: follow the slips          | Break the longest circle | 100.00 %                   | 100.00 %                | 72232                |
| 20000      | 200                 | Best strategy: follow the slips          | Do nothing               | 31.19 %                    | 30.93 %                 | 73799                |
| 20000      | 200                 | Cheating strategy: open all boxes        | Break the longest circle | 100.00 %                   | 100.00 %                | 48046                |
| 20000      | 200                 | Cheating strategy: open all boxes        | Do nothing               | 100.00 %                   | 30.93 %                 | 44876                |
| 20000      | 200                 | First closed: open the first box you see | Break the longest circle | 0.00 %                     | 100.00 %                | 60815                |
| 20000      | 200                 | First closed: open the first box you see | Do nothing               | 0.00 %                     | 30.93 %                 | 57150                |

Took 82873 ms in total to compute all runs.
