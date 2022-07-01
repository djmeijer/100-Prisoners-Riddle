# 100 Prisoners Riddle

- After seeing this: https://www.youtube.com/watch?v=iSNsgj1OCLA
- Probability reaches 1 - ln 2
- After first prisoner exchanges the flips of two boxes, after seeing all the bloxes and flips, survival rate is 100%!


| Number of prisoners | Group strategy | First person strategy | Survival probability | Iterations | Time to compute (ms) |
| - |  - |  - |  - |  - |  - |
| 100 | Cheating strategy: open all boxes  |  Do nothing                         | 100.00 % | 2000 | 856  |
| 100 | Cheating strategy: open all boxes  | Open 2 random boxes, exchange flips | 100.00 % | 2000 | 880  |
| 100 | Cheating strategy: open all boxes  | Break the longest circle            | 100.00 % | 2000 | 1017 |
| 100 | Random: open the first box you see | Do nothing                          | 0.00 %   | 2000 | 753  |
| 100 | Random: open the first box you see | Open 2 random boxes, exchange flips | 0.00 %   | 2000 | 787  |
| 100 | Random: open the first box you see | Break the longest circle            | 0.00 %   | 2000 | 923  |
| 100 | Best strategy: follow the slips    | Do nothing                          | 31.90 %  | 2000 | 499  |
| 100 | Best strategy: follow the slips    | Open 2 random boxes, exchange flips | 31.70 %  | 2000 | 531  |
| 100 | Best strategy: follow the slips    | Break the longest circle            | 100.00 % | 2000 | 592  |
| 200 | Cheating strategy: open all boxes  | Do nothing                          | 100.00 % | 2000 | 3259 |
| 200 | Cheating strategy: open all boxes  | Open 2 random boxes, exchange flips | 100.00 % | 2000 | 3216 |
| 200 | Cheating strategy: open all boxes  | Break the longest circle            | 100.00 % | 2000 | 3701 |
| 200 | Random: open the first box you see | Do nothing                          | 0.00 %   | 2000 | 3191 |
| 200 | Random: open the first box you see | Open 2 random boxes, exchange flips | 0.00 %   | 2000 | 3196 |
| 200 | Random: open the first box you see | Break the longest circle            | 0.00 %   | 2000 | 3689 |
| 200 | Best strategy: follow the slips    | Do nothing                          | 30.85 %  | 2000 | 1850 |
| 200 | Best strategy: follow the slips    | Open 2 random boxes, exchange flips | 31.50 %  | 2000 | 1899 |
| 200 | Best strategy: follow the slips    | Break the longest circle            | 100.00 % | 2000 | 2183 |