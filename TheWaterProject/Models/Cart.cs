﻿namespace TheWaterProject.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Project proj, int quantity)
        {
            CartLine? line = Lines
                .Where(x => x.Project.ProjectId == proj.ProjectId)
                .FirstOrDefault();
            if (line == null) 
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Project proj) => Lines.RemoveAll(x =>  x.Project.ProjectId == proj.ProjectId);

        public virtual void Clear() => Lines.Clear();

        public decimal CalculateTotal()
        {
            var blah = Lines.Sum(x => 25 * x.Quantity);
            return (blah);
        }
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }
    }
}
