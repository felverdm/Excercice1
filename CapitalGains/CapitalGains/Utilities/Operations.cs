using CapitalGains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalGains.Utilities
{
    public class Operations
    {
        public List<Input> CalculateTaxes(List<Input> jsonInput)
        {
            foreach (Input input in jsonInput)
            {
                int currentStcok = 0;
                double averagePrice = 0.00;
                double losses = 0.00;
                double taxRate = 0.20;
                double taxMinProfit = 20000.00;
                double tempOperationProfit = 0.00;
                foreach (BaseInput baseInput in input.InputCapitalGains)
                {
                    if (baseInput.Operation.Contains("buy"))
                    {
                        baseInput.Tax = 0.00;
                        averagePrice = Math.Round(((averagePrice * currentStcok) + (baseInput.UnitCost * baseInput.Quantity)) / (currentStcok + baseInput.Quantity), 2);
                        currentStcok = currentStcok + baseInput.Quantity;
                    }
                    else
                    {
                        if (averagePrice == baseInput.UnitCost)
                        {
                            baseInput.Tax = 0.00;
                        }
                        else
                        {
                            if (averagePrice > baseInput.UnitCost)
                            {
                                baseInput.Tax = 0.00;
                                losses = losses + ((averagePrice * baseInput.Quantity) - (baseInput.UnitCost * baseInput.Quantity));
                            }
                            else
                            {
                                tempOperationProfit = ((baseInput.UnitCost * baseInput.Quantity) - (averagePrice * baseInput.Quantity));
                                if (baseInput.UnitCost * baseInput.Quantity > taxMinProfit)
                                {
                                    if (losses > 0)
                                    {
                                        if (losses > tempOperationProfit)
                                        {
                                            losses = losses - tempOperationProfit;
                                            baseInput.Tax = 0.00;
                                        }
                                        else
                                        {
                                            baseInput.Tax = ((tempOperationProfit - losses) * taxRate);
                                            losses = 0;
                                        }
                                    }
                                    else
                                    {
                                        baseInput.Tax = tempOperationProfit * taxRate;
                                    }
                                }
                                else
                                {
                                    baseInput.Tax = 0.00;
                                }
                            }
                        }
                        currentStcok = currentStcok - baseInput.Quantity;
                    }

                }
            }
            return jsonInput;
        }
    }
}
