// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_bbc3b7dcfd
ROOST_METHOD_SIG_HASH=Run_23f9485d25

   ########## Test-Scenarios ##########  

Based on the provided method and related code, I'll generate NUnit test scenarios for the `Run` method of the `BreadthFirstSearch` class. Here are the test scenarios:

Scenario 1: Null Graph Handling

Details:
  TestName: ThrowArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is provided.
Execution:
  Arrange: Create a BreadthFirstSearch instance and set up a null graph and a valid start vertex.
  Act: Call the Run method with the null graph and valid start vertex.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input for the graph parameter, maintaining robustness and preventing null reference exceptions later in the execution.

Scenario 2: Basic BFS Traversal

Details:
  TestName: CorrectlyTraversesSimpleGraph
  Description: Ensure that the BFS algorithm correctly traverses a simple graph and sets the correct distances and predecessors.
Execution:
  Arrange: Create a simple graph with known structure, initialize a BreadthFirstSearch instance, and choose a start vertex.
  Act: Call the Run method with the created graph and start vertex.
  Assert: Verify that each vertex has the correct distance and predecessor set.
Validation:
  This test confirms that the BFS algorithm correctly explores the graph in breadth-first order, setting appropriate distances and predecessors for each vertex.

Scenario 3: Isolated Vertex Handling

Details:
  TestName: HandlesIsolatedVerticesCorrectly
  Description: Verify that the algorithm correctly handles isolated vertices in the graph.
Execution:
  Arrange: Create a graph with some connected vertices and one or more isolated vertices. Initialize a BreadthFirstSearch instance.
  Act: Call the Run method with the graph and a start vertex from the connected portion.
  Assert: Check that isolated vertices remain unprocessed (distance should be Int32.MaxValue and predecessor should be null).
Validation:
  This test ensures that the BFS algorithm doesn't incorrectly process vertices that are not reachable from the start vertex.

Scenario 4: Cyclic Graph Traversal

Details:
  TestName: CorrectlyTraversesCyclicGraph
  Description: Ensure that the BFS algorithm correctly handles cycles in the graph without getting stuck in infinite loops.
Execution:
  Arrange: Create a graph with at least one cycle, initialize a BreadthFirstSearch instance, and choose a start vertex.
  Act: Call the Run method with the cyclic graph and start vertex.
  Assert: Verify that all vertices are processed exactly once and have correct distances and predecessors.
Validation:
  This test confirms that the BFS algorithm can handle cyclic graphs without issues, ensuring it doesn't revisit already processed vertices.

Scenario 5: Large Graph Performance

Details:
  TestName: PerformsEfficientlyOnLargeGraph
  Description: Verify that the BFS algorithm performs efficiently on a large graph within a reasonable time frame.
Execution:
  Arrange: Create a large graph with many vertices and edges, initialize a BreadthFirstSearch instance, and choose a start vertex.
  Act: Measure the time taken to call and complete the Run method with the large graph and start vertex.
  Assert: Verify that the execution time is within an acceptable range and that all vertices are correctly processed.
Validation:
  This test ensures that the BFS implementation remains efficient and scalable for larger graphs, which is crucial for real-world applications.

Scenario 6: Start Vertex Initialization

Details:
  TestName: CorrectlyInitializesStartVertex
  Description: Ensure that the start vertex is correctly initialized with distance 0 and no predecessor.
Execution:
  Arrange: Create a graph, initialize a BreadthFirstSearch instance, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that the start vertex has a distance of 0 and null predecessor.
Validation:
  This test confirms that the algorithm correctly sets up the starting point for the BFS traversal.

These test scenarios cover various aspects of the BreadthFirstSearch implementation, including error handling, correct traversal, and performance considerations. They should provide good coverage for the given method.


*/

// ********RoostGPT********
using NUnit.Framework;
using LunarDoggo.Datastructures.Graphs;
using LunarDoggo.Algorithms.Graphs.Pathfinding;
using System;
using System.Linq;

namespace LunarDoggo.Algorithms.Graphs.Pathfinding.Test
{
    [TestFixture]
    public class RunTest
    {
        [Test, Category("invalid")]
        public void ThrowArgumentNullExceptionWhenGraphIsNull()
        {
            var bfs = new BreadthFirstSearch();
            var startVertex = new Vertex<BFSVertex>(0, new BFSVertex());

            Assert.Throws<ArgumentNullException>(() => bfs.Run(null, startVertex));
        }

        [Test, Category("valid")]
        public void CorrectlyTraversesSimpleGraph()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            var bfs = new BreadthFirstSearch();
            bfs.Run(graph, v1);

            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(2, v3.Value.Distance);
            Assert.IsNull(v1.Value.Predecessor);
            Assert.AreEqual(v1, v2.Value.Predecessor);
            Assert.AreEqual(v2, v3.Value.Predecessor);
        }

        [Test, Category("valid")]
        public void HandlesIsolatedVerticesCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var isolated = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);

            var bfs = new BreadthFirstSearch();
            bfs.Run(graph, v1);

            Assert.AreEqual(Int32.MaxValue, isolated.Value.Distance);
            Assert.IsNull(isolated.Value.Predecessor);
            Assert.IsFalse(isolated.Value.Processed);
        }

        [Test, Category("valid")]
        public void CorrectlyTraversesCyclicGraph()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            var bfs = new BreadthFirstSearch();
            bfs.Run(graph, v1);

            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(1, v3.Value.Distance);
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
        }

        [Test, Category("valid")]
        public void PerformsEfficientlyOnLargeGraph()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var vertices = Enumerable.Range(0, 10000).Select(_ => graph.AddVertex(new BFSVertex())).ToList();
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                graph.AddEdge(vertices[i], vertices[i + 1]);
            }

            var bfs = new BreadthFirstSearch();
            var startTime = DateTime.Now;
            bfs.Run(graph, vertices[0]);
            var endTime = DateTime.Now;

            Assert.Less((endTime - startTime).TotalSeconds, 5); // Assuming 5 seconds is a reasonable time limit
            Assert.IsTrue(vertices.All(v => v.Value.Processed));
        }

        [Test, Category("valid")]
        public void CorrectlyInitializesStartVertex()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var start = graph.AddVertex(new BFSVertex());
            var other = graph.AddVertex(new BFSVertex());
            graph.AddEdge(start, other);

            var bfs = new BreadthFirstSearch();
            bfs.Run(graph, start);

            Assert.AreEqual(0, start.Value.Distance);
            Assert.IsNull(start.Value.Predecessor);
            Assert.IsTrue(start.Value.Processed);
        }
    }
}
