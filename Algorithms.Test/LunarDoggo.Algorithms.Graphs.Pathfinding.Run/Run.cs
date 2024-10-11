// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCppEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_bbc3b7dcfd
ROOST_METHOD_SIG_HASH=Run_23f9485d25

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `BreadthFirstSearch` class:

Scenario 1: Valid Graph and Start Vertex

Details:
  TestName: RunBFSWithValidGraphAndStartVertex
  Description: Test the BFS algorithm with a valid graph and start vertex to ensure correct traversal and distance calculation.

Execution:
  Arrange: Create a valid graph with multiple vertices and edges, and select a start vertex.
  Act: Call the Run method with the created graph and start vertex.
  Assert: Check if all vertices are processed, distances are correctly set, and predecessors are properly assigned.

Validation:
  This test verifies that the BFS algorithm correctly traverses the graph, assigns distances, and sets predecessors for all reachable vertices from the start vertex.

Scenario 2: Null Graph Input

Details:
  TestName: RunBFSWithNullGraphThrowsArgumentNullException
  Description: Test that the method throws an ArgumentNullException when a null graph is provided.

Execution:
  Arrange: Prepare a null graph and a valid start vertex.
  Act: Call the Run method with the null graph and valid start vertex.
  Assert: Verify that an ArgumentNullException is thrown with the correct error message.

Validation:
  This test ensures that the method properly handles null input for the graph parameter and throws the expected exception.

Scenario 3: Disconnected Graph

Details:
  TestName: RunBFSWithDisconnectedGraph
  Description: Test the BFS algorithm on a graph with disconnected components.

Execution:
  Arrange: Create a graph with multiple disconnected components and select a start vertex in one component.
  Act: Call the Run method with the created graph and start vertex.
  Assert: Verify that vertices in the same component as the start vertex are processed, while vertices in other components remain unprocessed.

Validation:
  This test checks if the BFS algorithm correctly handles disconnected graphs by only processing reachable vertices.

Scenario 4: Graph with Cycles

Details:
  TestName: RunBFSWithCyclicGraph
  Description: Test the BFS algorithm on a graph containing cycles to ensure correct traversal.

Execution:
  Arrange: Create a graph with cycles and select a start vertex.
  Act: Call the Run method with the created graph and start vertex.
  Assert: Verify that all vertices are processed exactly once and have correct distances and predecessors.

Validation:
  This test ensures that the BFS algorithm correctly handles cycles in the graph without getting stuck in infinite loops.

Scenario 5: Single Vertex Graph

Details:
  TestName: RunBFSWithSingleVertexGraph
  Description: Test the BFS algorithm on a graph containing only one vertex.

Execution:
  Arrange: Create a graph with a single vertex and use it as the start vertex.
  Act: Call the Run method with the single-vertex graph and start vertex.
  Assert: Verify that the vertex is processed, has a distance of 0, and no predecessor.

Validation:
  This test checks if the BFS algorithm correctly handles the edge case of a graph with only one vertex.

Scenario 6: Large Graph Performance

Details:
  TestName: RunBFSWithLargeGraphPerformance
  Description: Test the performance of the BFS algorithm on a large graph.

Execution:
  Arrange: Create a large graph with many vertices and edges, and select a start vertex.
  Act: Measure the time taken to run the BFS algorithm on the large graph.
  Assert: Verify that the algorithm completes within an acceptable time frame and processes all vertices correctly.

Validation:
  This test ensures that the BFS algorithm can handle large graphs efficiently without excessive time or memory usage.

Scenario 7: Graph with Isolated Vertices

Details:
  TestName: RunBFSWithIsolatedVertices
  Description: Test the BFS algorithm on a graph containing isolated vertices (vertices with no edges).

Execution:
  Arrange: Create a graph with some connected vertices and some isolated vertices, and select a start vertex from the connected portion.
  Act: Call the Run method with the created graph and start vertex.
  Assert: Verify that connected vertices are processed and isolated vertices remain unprocessed.

Validation:
  This test checks if the BFS algorithm correctly handles graphs with isolated vertices by not processing them when unreachable from the start vertex.

These test scenarios cover various aspects of the BreadthFirstSearch.Run method, including normal operation, edge cases, and error handling. They should provide a comprehensive test suite for the given method.


*/

// ********RoostGPT********
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using LunarDoggo.Datastructures.Graphs;
using LunarDoggo.Algorithms.Graphs.Pathfinding;

namespace LunarDoggo.Algorithms.Graphs.Pathfinding.Test
{
    [TestFixture]
    public class RunTest
    {
        [Test]
        public void RunBFSWithValidGraphAndStartVertex()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var v4 = graph.AddVertex(new BFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v4);

            var bfs = new BreadthFirstSearch();

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.IsTrue(v4.Value.Processed);

            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(2, v3.Value.Distance);
            Assert.AreEqual(3, v4.Value.Distance);

            Assert.IsNull(v1.Value.Predecessor);
            Assert.AreEqual(v1, v2.Value.Predecessor);
            Assert.AreEqual(v2, v3.Value.Predecessor);
            Assert.AreEqual(v3, v4.Value.Predecessor);
        }

        [Test]
        public void RunBFSWithNullGraphThrowsArgumentNullException()
        {
            // Arrange
            var bfs = new BreadthFirstSearch();
            var startVertex = new Vertex<BFSVertex>(0, new BFSVertex());

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bfs.Run(null, startVertex));
        }

        [Test]
        public void RunBFSWithDisconnectedGraph()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var v4 = graph.AddVertex(new BFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v4);

            var bfs = new BreadthFirstSearch();

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsFalse(v3.Value.Processed);
            Assert.IsFalse(v4.Value.Processed);

            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(int.MaxValue, v3.Value.Distance);
            Assert.AreEqual(int.MaxValue, v4.Value.Distance);
        }

        [Test]
        public void RunBFSWithCyclicGraph()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var v4 = graph.AddVertex(new BFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v4, v1);

            var bfs = new BreadthFirstSearch();

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.IsTrue(v4.Value.Processed);

            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(1, v4.Value.Distance);
            Assert.AreEqual(2, v3.Value.Distance);
        }

        [Test]
        public void RunBFSWithSingleVertexGraph()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());

            var bfs = new BreadthFirstSearch();

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.IsTrue(v1.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.IsNull(v1.Value.Predecessor);
        }

        [Test]
        public void RunBFSWithLargeGraphPerformance()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var vertices = new List<Vertex<BFSVertex>>();
            for (int i = 0; i < 10000; i++)
            {
                vertices.Add(graph.AddVertex(new BFSVertex()));
            }

            for (int i = 0; i < 9999; i++)
            {
                graph.AddEdge(vertices[i], vertices[i + 1]);
            }

            var bfs = new BreadthFirstSearch();

            // Act
            var startTime = DateTime.Now;
            bfs.Run(graph, vertices[0]);
            var endTime = DateTime.Now;

            // Assert
            var duration = (endTime - startTime).TotalSeconds;
            Assert.Less(duration, 5, "BFS took too long to complete");

            Assert.IsTrue(vertices.All(v => v.Value.Processed));
            for (int i = 0; i < 10000; i++)
            {
                Assert.AreEqual(i, vertices[i].Value.Distance);
            }
        }

        [Test]
        public void RunBFSWithIsolatedVertices()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var isolated = graph.AddVertex(new BFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            var bfs = new BreadthFirstSearch();

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.IsFalse(isolated.Value.Processed);

            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(2, v3.Value.Distance);
            Assert.AreEqual(int.MaxValue, isolated.Value.Distance);

            Assert.IsNull(isolated.Value.Predecessor);
        }
    }
}
