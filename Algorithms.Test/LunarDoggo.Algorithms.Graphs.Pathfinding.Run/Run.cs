// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_bbc3b7dcfd
ROOST_METHOD_SIG_HASH=Run_23f9485d25

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `BreadthFirstSearch` class:

Scenario 1: Null Graph Handling

Details:
  TestName: ThrowArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is passed.
Execution:
  Arrange: Create a BreadthFirstSearch instance and set up a null graph and a valid start vertex.
  Act: Call the Run method with the null graph and valid start vertex.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input for the graph parameter, maintaining robustness and preventing null reference exceptions later in the execution.

Scenario 2: Single Vertex Graph

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Ensure the method correctly processes a graph with only one vertex.
Execution:
  Arrange: Create a graph with a single vertex and set it as the start vertex.
  Act: Run the BFS algorithm on this graph.
  Assert: Verify that the vertex is processed, its distance is 0, and it has no predecessor.
Validation:
  This test confirms that the BFS algorithm works correctly for the simplest possible graph, setting a baseline for more complex scenarios.

Scenario 3: Linear Graph Traversal

Details:
  TestName: TraverseLinearGraphCorrectly
  Description: Check if the BFS algorithm correctly traverses a linear graph (each vertex connected to at most two others).
Execution:
  Arrange: Create a linear graph with multiple vertices.
  Act: Run the BFS algorithm starting from one end of the graph.
  Assert: Verify that each vertex is processed in order, distances increase linearly, and predecessors are set correctly.
Validation:
  This scenario tests the basic functionality of BFS in a simple, predictable graph structure, ensuring correct distance calculation and predecessor assignment.

Scenario 4: Cyclic Graph Handling

Details:
  TestName: HandleCyclicGraphWithoutInfiniteLoop
  Description: Verify that the BFS algorithm correctly handles a graph with cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a graph with at least one cycle.
  Act: Run the BFS algorithm on this graph.
  Assert: Check that all vertices are processed exactly once and have correct distances and predecessors.
Validation:
  This test ensures that the algorithm can handle more complex graph structures with cycles, which is crucial for its robustness and applicability to real-world scenarios.

Scenario 5: Disconnected Graph Components

Details:
  TestName: ProcessOnlyReachableVerticesInDisconnectedGraph
  Description: Ensure that BFS only processes vertices reachable from the start vertex in a disconnected graph.
Execution:
  Arrange: Create a graph with multiple disconnected components.
  Act: Run BFS starting from a vertex in one component.
  Assert: Verify that only vertices in the same component as the start vertex are processed, while others remain unprocessed.
Validation:
  This scenario tests the algorithm's behavior with disconnected graphs, ensuring it doesn't attempt to process unreachable vertices.

Scenario 6: Large Graph Performance

Details:
  TestName: CompleteTraversalOfLargeGraphWithinReasonableTime
  Description: Test the performance of the BFS algorithm on a large graph to ensure it completes within a reasonable time frame.
Execution:
  Arrange: Create a large graph with many vertices and edges.
  Act: Run the BFS algorithm and measure the execution time.
  Assert: Verify that the algorithm completes within an acceptable time limit and processes all vertices correctly.
Validation:
  This test assesses the algorithm's efficiency and scalability, which is important for its practical application to large datasets.

Scenario 7: Start Vertex Initialization

Details:
  TestName: InitializeStartVertexCorrectly
  Description: Ensure that the start vertex is correctly initialized with distance 0 and marked as processed.
Execution:
  Arrange: Create a graph and designate a start vertex.
  Act: Run the BFS algorithm.
  Assert: Verify that the start vertex has a distance of 0, is marked as processed, and has no predecessor.
Validation:
  This test confirms that the algorithm correctly sets up the initial conditions for the BFS traversal.

These scenarios cover various aspects of the BreadthFirstSearch algorithm, including edge cases, error handling, and performance considerations. They aim to thoroughly test the functionality and robustness of the implementation.


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
            // Arrange
            var bfs = new BreadthFirstSearch();
            IGraph<BFSVertex> graph = null;
            var startVertex = new Vertex<BFSVertex>(0, new BFSVertex());

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bfs.Run(graph, startVertex));
        }

        [Test, Category("valid")]
        public void ProcessSingleVertexGraphCorrectly()
        {
            // Arrange
            var bfs = new BreadthFirstSearch();
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var vertex = graph.AddVertex(new BFSVertex());

            // Act
            bfs.Run(graph, vertex);

            // Assert
            Assert.That(vertex.Value.Processed, Is.True);
            Assert.That(vertex.Value.Distance, Is.EqualTo(0));
            Assert.That(vertex.Value.Predecessor, Is.Null);
        }

        [Test, Category("valid")]
        public void TraverseLinearGraphCorrectly()
        {
            // Arrange
            var bfs = new BreadthFirstSearch();
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(2));
            Assert.That(v1.Value.Predecessor, Is.Null);
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v2));
        }

        [Test, Category("valid")]
        public void HandleCyclicGraphWithoutInfiniteLoop()
        {
            // Arrange
            var bfs = new BreadthFirstSearch();
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(1));
            Assert.That(v1.Value.Predecessor, Is.Null);
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v1));
        }

        [Test, Category("valid")]
        public void ProcessOnlyReachableVerticesInDisconnectedGraph()
        {
            // Arrange
            var bfs = new BreadthFirstSearch();
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var v4 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v4);

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.That(v1.Value.Processed, Is.True);
            Assert.That(v2.Value.Processed, Is.True);
            Assert.That(v3.Value.Processed, Is.False);
            Assert.That(v4.Value.Processed, Is.False);
        }

        [Test, Category("valid")]
        public void CompleteTraversalOfLargeGraphWithinReasonableTime()
        {
            // Arrange
            var bfs = new BreadthFirstSearch();
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var vertices = Enumerable.Range(0, 10000).Select(_ => graph.AddVertex(new BFSVertex())).ToList();
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                graph.AddEdge(vertices[i], vertices[i + 1]);
            }

            // Act
            var startTime = DateTime.Now;
            bfs.Run(graph, vertices[0]);
            var endTime = DateTime.Now;

            // Assert
            Assert.That((endTime - startTime).TotalSeconds, Is.LessThan(5));
            Assert.That(vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void InitializeStartVertexCorrectly()
        {
            // Arrange
            var bfs = new BreadthFirstSearch();
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var startVertex = graph.AddVertex(new BFSVertex());
            var otherVertex = graph.AddVertex(new BFSVertex());
            graph.AddEdge(startVertex, otherVertex);

            // Act
            bfs.Run(graph, startVertex);

            // Assert
            Assert.That(startVertex.Value.Distance, Is.EqualTo(0));
            Assert.That(startVertex.Value.Processed, Is.True);
            Assert.That(startVertex.Value.Predecessor, Is.Null);
        }
    }
}
