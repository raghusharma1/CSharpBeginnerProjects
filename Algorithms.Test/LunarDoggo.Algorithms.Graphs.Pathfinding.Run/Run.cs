// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_bbc3b7dcfd
ROOST_METHOD_SIG_HASH=Run_23f9485d25

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `BreadthFirstSearch` class:

Scenario 1: Null Graph Handling

Details:
  TestName: ThrowsArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is passed.
Execution:
  Arrange: Create a BreadthFirstSearch instance and prepare a null graph and a valid start vertex.
  Act: Call the Run method with the null graph and valid start vertex.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input for the graph parameter, maintaining robustness and preventing null reference exceptions later in the execution.

Scenario 2: Single Vertex Graph

Details:
  TestName: ProcessesSingleVertexGraphCorrectly
  Description: Ensure the method correctly processes a graph with only one vertex (the start vertex).
Execution:
  Arrange: Create a graph with a single vertex, set it as the start vertex, and instantiate BreadthFirstSearch.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that the start vertex is processed (Processed = true) and has a Distance of 0.
Validation:
  This test confirms that the algorithm works correctly for the simplest possible graph, setting the base case for more complex scenarios.

Scenario 3: Linear Graph Traversal

Details:
  TestName: TraversesLinearGraphCorrectly
  Description: Check if the method correctly traverses a linear graph (vertices connected in a line).
Execution:
  Arrange: Create a linear graph with multiple vertices, set the first as the start vertex, and instantiate BreadthFirstSearch.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that all vertices are processed, distances increase linearly, and predecessors are set correctly.
Validation:
  This scenario tests the basic functionality of BFS in a simple, predictable graph structure, ensuring correct distance calculation and predecessor assignment.

Scenario 4: Cyclic Graph Handling

Details:
  TestName: HandlesCyclicGraphWithoutInfiniteLoop
  Description: Ensure the method correctly processes a graph containing cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a graph with cycles, choose a start vertex, and instantiate BreadthFirstSearch.
  Act: Call the Run method with the cyclic graph and start vertex.
  Assert: Verify that all vertices are processed exactly once and have correct distances and predecessors.
Validation:
  This test is crucial to ensure that the BFS algorithm can handle graphs with cycles, which is a common scenario in real-world applications.

Scenario 5: Disconnected Graph Components

Details:
  TestName: ProcessesOnlyReachableVerticesInDisconnectedGraph
  Description: Verify that the method only processes vertices reachable from the start vertex in a disconnected graph.
Execution:
  Arrange: Create a graph with multiple disconnected components, choose a start vertex in one component, and instantiate BreadthFirstSearch.
  Act: Call the Run method with the disconnected graph and start vertex.
  Assert: Check that only vertices in the same component as the start vertex are processed, while others remain unprocessed.
Validation:
  This scenario ensures that the BFS algorithm correctly handles disconnected graphs, which is important for applications dealing with partial or fragmented data structures.

Scenario 6: Large Graph Performance

Details:
  TestName: CompletesLargeGraphTraversalInReasonableTime
  Description: Test the performance of the method on a large graph to ensure it completes in a reasonable time.
Execution:
  Arrange: Generate a large graph (e.g., 10,000+ vertices), choose a start vertex, and instantiate BreadthFirstSearch.
  Act: Measure the time taken to call and complete the Run method.
  Assert: Verify that the execution time is within an acceptable range and all vertices are processed.
Validation:
  This test is important to ensure the algorithm's efficiency and scalability for large datasets, which is crucial for real-world applications.

Scenario 7: Correct Initialization of Vertices

Details:
  TestName: InitializesAllVerticesCorrectlyBeforeTraversal
  Description: Ensure that all vertices in the graph are correctly initialized before the BFS traversal begins.
Execution:
  Arrange: Create a graph with multiple vertices, choose a start vertex, and instantiate BreadthFirstSearch.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that immediately after initialization (before the main while loop), all vertices except the start have Distance = Int32.MaxValue, Predecessor = null, and Processed = false. The start vertex should have Distance = 0 and Processed = true.
Validation:
  This test ensures that the Initialize method correctly sets up the graph for traversal, which is crucial for the correct functioning of the BFS algorithm.

These test scenarios cover various aspects of the BreadthFirstSearch.Run method, including edge cases, error handling, and performance considerations. They should provide a comprehensive test suite for validating the correctness and robustness of the BFS implementation.


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
        [Test]
        public void ThrowsArgumentNullExceptionWhenGraphIsNull()
        {
            var bfs = new BreadthFirstSearch();
            var startVertex = new Vertex<BFSVertex>(0, new BFSVertex());

            Assert.Throws<ArgumentNullException>(() => bfs.Run(null, startVertex));
        }

        [Test]
        public void ProcessesSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var startVertex = graph.AddVertex(new BFSVertex());
            var bfs = new BreadthFirstSearch();

            bfs.Run(graph, startVertex);

            Assert.IsTrue(startVertex.Value.Processed);
            Assert.AreEqual(0, startVertex.Value.Distance);
        }

        [Test]
        public void TraversesLinearGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            var bfs = new BreadthFirstSearch();
            bfs.Run(graph, v1);

            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(2, v3.Value.Distance);
            Assert.IsNull(v1.Value.Predecessor);
            Assert.AreEqual(v1, v2.Value.Predecessor);
            Assert.AreEqual(v2, v3.Value.Predecessor);
        }

        [Test]
        public void HandlesCyclicGraphWithoutInfiniteLoop()
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

            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(1, v3.Value.Distance);
        }

        [Test]
        public void ProcessesOnlyReachableVerticesInDisconnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var v4 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v4);

            var bfs = new BreadthFirstSearch();
            bfs.Run(graph, v1);

            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsFalse(v3.Value.Processed);
            Assert.IsFalse(v4.Value.Processed);
        }

        [Test]
        public void CompletesLargeGraphTraversalInReasonableTime()
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

            Assert.Less((endTime - startTime).TotalSeconds, 5);
            Assert.IsTrue(vertices.All(v => v.Value.Processed));
        }

        [Test]
        public void InitializesAllVerticesCorrectlyBeforeTraversal()
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
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsNull(v1.Value.Predecessor);

            Assert.AreEqual(1, v2.Value.Distance);
            Assert.IsTrue(v2.Value.Processed);
            Assert.AreEqual(v1, v2.Value.Predecessor);

            Assert.AreEqual(2, v3.Value.Distance);
            Assert.IsTrue(v3.Value.Processed);
            Assert.AreEqual(v2, v3.Value.Predecessor);
        }
    }
}
