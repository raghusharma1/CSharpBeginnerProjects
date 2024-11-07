// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_bbc3b7dcfd
ROOST_METHOD_SIG_HASH=Run_23f9485d25

   ########## Test-Scenarios ##########  

Based on the provided method and context, here are several test scenarios for the `Run` method of the `BreadthFirstSearch` class:

Scenario 1: Null Graph Input

Details:
  TestName: ThrowArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is provided.
Execution:
  Arrange: Create a BreadthFirstSearch instance and set up a null graph and a valid start vertex.
  Act: Call the Run method with the null graph and valid start vertex.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input for the graph parameter, maintaining robustness and preventing null reference exceptions later in the execution.

Scenario 2: Valid Graph with Single Vertex

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Ensure the method correctly processes a graph with only one vertex (the start vertex).
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with a single vertex, and set this vertex as the start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that the start vertex has been processed (Processed = true), has a Distance of 0, and has no Predecessor.
Validation:
  This test confirms that the method correctly initializes and processes the simplest possible graph, setting the base case for more complex scenarios.

Scenario 3: Graph with Multiple Vertices

Details:
  TestName: ProcessMultiVertexGraphCorrectly
  Description: Verify that the method correctly processes a graph with multiple vertices, setting appropriate distances and predecessors.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple vertices connected in a known structure, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices have been processed, have correct Distance values based on their position relative to the start vertex, and have appropriate Predecessor assignments.
Validation:
  This test ensures that the breadth-first search algorithm is correctly implemented, visiting vertices in the right order and assigning correct distance and predecessor information.

Scenario 4: Disconnected Graph

Details:
  TestName: HandleDisconnectedGraphCorrectly
  Description: Ensure the method correctly processes a disconnected graph, leaving unreachable vertices unprocessed.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple disconnected components, and choose a start vertex in one component.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that all vertices in the same component as the start vertex are processed and have correct Distance and Predecessor values, while vertices in other components remain unprocessed (Processed = false, Distance = Int32.MaxValue, Predecessor = null).
Validation:
  This test confirms that the method correctly handles disconnected graphs, processing only the reachable vertices and leaving others untouched.

Scenario 5: Cyclic Graph

Details:
  TestName: ProcessCyclicGraphWithoutInfiniteLoop
  Description: Verify that the method correctly processes a graph containing cycles without entering an infinite loop.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with cycles, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices have been processed exactly once, have correct Distance values, and have appropriate Predecessor assignments.
Validation:
  This test ensures that the method can handle cyclic graphs without revisiting vertices or entering infinite loops, which is crucial for the correctness of the breadth-first search algorithm.

Scenario 6: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Ensure the method can process a large graph within a reasonable time frame.
Execution:
  Arrange: Create a BreadthFirstSearch instance, generate a large graph with many vertices and edges, and choose a start vertex.
  Act: Measure the time taken to call the Run method with the large graph and start vertex.
  Assert: Verify that the method completes within an acceptable time limit and that all vertices are correctly processed.
Validation:
  This test checks the performance characteristics of the method, ensuring it can handle large-scale graphs efficiently, which is important for real-world applications.

These test scenarios cover various aspects of the `Run` method, including input validation, correctness for different graph structures, and performance considerations. They should provide a comprehensive test suite for the BreadthFirstSearch implementation.


*/

// ********RoostGPT********
using NUnit.Framework;
using System;
using System.Collections.Generic;
using LunarDoggo.Datastructures.Graphs;
using LunarDoggo.Algorithms.Graphs.Pathfinding;

namespace LunarDoggo.Algorithms.Graphs.Pathfinding.Test
{
    [TestFixture]
    public class RunTest
    {
        private BreadthFirstSearch bfs;

        [SetUp]
        public void Setup()
        {
            bfs = new BreadthFirstSearch();
        }

        [Test, Category("invalid")]
        public void ThrowArgumentNullExceptionWhenGraphIsNull()
        {
            // Arrange
            IGraph<BFSVertex> graph = null;
            Vertex<BFSVertex> start = new Vertex<BFSVertex>(0, new BFSVertex());

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bfs.Run(graph, start));
        }

        [Test, Category("valid")]
        public void ProcessSingleVertexGraphCorrectly()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var vertex = graph.AddVertex(new BFSVertex());

            // Act
            bfs.Run(graph, vertex);

            // Assert
            Assert.IsTrue(vertex.Value.Processed);
            Assert.AreEqual(0, vertex.Value.Distance);
            Assert.IsNull(vertex.Value.Predecessor);
        }

        [Test, Category("valid")]
        public void ProcessMultiVertexGraphCorrectly()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            // Act
            bfs.Run(graph, v1);

            // Assert
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

        [Test, Category("valid")]
        public void HandleDisconnectedGraphCorrectly()
        {
            // Arrange
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);

            // Act
            bfs.Run(graph, v1);

            // Assert
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsFalse(v3.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(int.MaxValue, v3.Value.Distance);
            Assert.IsNull(v1.Value.Predecessor);
            Assert.AreEqual(v1, v2.Value.Predecessor);
            Assert.IsNull(v3.Value.Predecessor);
        }

        [Test, Category("valid")]
        public void ProcessCyclicGraphWithoutInfiniteLoop()
        {
            // Arrange
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
            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(1, v3.Value.Distance);
            Assert.IsNull(v1.Value.Predecessor);
            Assert.AreEqual(v1, v2.Value.Predecessor);
            Assert.AreEqual(v1, v3.Value.Predecessor);
        }

        [Test, Category("valid")]
        public void ProcessLargeGraphWithinReasonableTime()
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

            // Act
            var startTime = DateTime.Now;
            bfs.Run(graph, vertices[0]);
            var endTime = DateTime.Now;

            // Assert
            Assert.Less((endTime - startTime).TotalSeconds, 5); // Assuming 5 seconds is reasonable
            Assert.IsTrue(vertices.TrueForAll(v => v.Value.Processed));
            Assert.AreEqual(9999, vertices[9999].Value.Distance);
        }
    }
}
