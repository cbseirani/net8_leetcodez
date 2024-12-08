namespace LeetCodeSolutions.Basics.Data_Structs;

public class GraphInt
{
    private readonly Dictionary<int, List<int>> _adjList = new ();
    
    // Add an edge to the graph
    public void AddEdge(int vertex1, int vertex2)
    {
        if (!_adjList.ContainsKey(vertex1))
            AddVertex(vertex1);

        if (!_adjList.ContainsKey(vertex2))
            AddVertex(vertex2);

        _adjList[vertex1].Add(vertex2);
        _adjList[vertex2].Add(vertex1);  // For undirected graph
    }
    
    // Add a vertex to the graph
    private void AddVertex(int vertex)
    {
        if (!_adjList.ContainsKey(vertex))
            _adjList[vertex] = new List<int>();
    }
    
    // Print the graph
    public void PrintGraph()
    {
        foreach (var vertex in _adjList)
        {
            Console.Write(vertex.Key + " -> ");
            
            foreach (var edge in vertex.Value)
                Console.Write(edge + " ");

            Console.WriteLine();
        }
    }
}