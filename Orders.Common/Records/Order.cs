﻿

namespace Orders.Common.Records;

public record Order
{
    public int Id { get; } = default;
    public string Customer { get; } = string.Empty;
    public string Address { get; } = string.Empty;
    public List<LineItem> Items { get; } = new();
    public Order(int id, string customer, string address) 
    {
        try
        {
            if (id < 1) throw new ArgumentException("Id must be greater than 0.");
            if (customer.Equals(string.Empty) || customer == default) throw new ArgumentException("Customer name cannot be empty.");
            if (address.Equals(string.Empty) || address == default) throw new ArgumentException("Adress cannot be empty.");
            Id = id;
            Customer = customer;
            Address = address;
        }
        catch { throw; }
    }
    public void AddLineItems (string product, int quantity, double price, double vat)
    {
        try
        {
            Items.Add(new LineItem(Id, Items.Count + 1, product, quantity, price, vat));
        }
        catch (ArgumentException ex)
        {
            ex.Data.Add("Order Id",Id);
            ex.Data.Add("Line item Id", Items.Count+1);
            ex.Data.Add("Product", product);
            ex.Data.Add("Quantity", quantity);
            ex.Data.Add("Price", price);
            ex.Data.Add("VAT", vat);
            throw ex;
        }
    }
    public void GetOrderTotalAndVat(out double total, out double vat) => 
        (total, vat) = (Items.Sum(i => i.Total), Items.Sum(i => i.Vat));

}
