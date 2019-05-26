using System;
using System.Collections.Generic;
using System.Linq;
namespace GenericsBuilder
{
    public class TriangleRegistryList 
    {
        public TriangleRegistryList()
        {
            this.AdjacentShapeNumbers = new List<int>();
        }
        public List<int> AdjacentShapeNumbers {get;set;}

        public bool IsAdjacentTo(TriangleRegistryList other)
        {
            var isAdjacentTo =  GetPoints().Intersect(other.GetPoints()).ToList().Count() >= 2;
            if(isAdjacentTo){
                this.AdjacentShapeNumbers.Add(other.ShapeNum);
            }
            return isAdjacentTo;
        }
        public float x1 { get; set; }
        public float y1 { get; set; }
        public float x2 { get; set; }
        public float y2 { get; set; }
        public float x3 { get; set; }
        public float y3 { get; set; }
        public int ShapeNum { get; set; }
        
        public IEnumerable<(float x, float y)> GetPoints()
        {
            yield return (x1, y1);
            yield return (x2, y2);
            yield return (x3, y3);
        }

            /* 
            var triangles = new List<TriangleRegistryList>();

            triangles.Add(new TriangleRegistryList{ x1 = 1, y1 = 3, x2 = 2, y2 = 3, x3 = 2, y3 = 4, ShapeNum = 1 });
            triangles.Add(new TriangleRegistryList{ x1 = 3, y1 = 3, x2 = 2, y2 = 3, x3 = 2, y3 = 4, ShapeNum = 2 });
            //triangles.Add(new TriangleRegistryList{ x1 = 2, y1 = 2, x2 = 2, y2 = 3, x3 = 3, y3 = 3, ShapeNum = 3 });

            
            var triangles2 = new List<TriangleRegistryList>();
            triangles2.Add(new TriangleRegistryList{ x1 = 3, y1 = 3, x2 = 2, y2 = 3, x3 = 2, y3 = 4, ShapeNum = 1 });
            triangles2.Add(new TriangleRegistryList{ x1 = 2, y1 = 2, x2 = 2, y2 = 3, x3 = 3, y3 = 3, ShapeNum = 2 });
            */
            
            /* 
            
            var sharedEdges = triangles.GetKCombs(2).Where(
                                        t => t.First().IsAdjacentTo(t.Skip(1).Take(1).Single()) 
                                        && t.First().ShapeNum == 1);

                                        
            var sharedEdges2 = triangles2.GetKCombs(2).Where(
                                        t => t.First().IsAdjacentTo(t.Skip(1).Take(1).Single()) 
                                        && t.First().ShapeNum == 1);
            */
        
    }
}