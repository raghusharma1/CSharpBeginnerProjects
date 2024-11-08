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
  Assert: Verify that an ArgumentNullException is thrown with the correct message.
Validation:
  This test ensures that the method properly handles null input for the graph parameter, maintaining robustness and preventing null reference exceptions later in the execution.

Scenario 2: Valid Graph with Single Vertex

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Ensure the method correctly processes a graph with only one vertex (the start vertex).
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with a single vertex, and set this vertex as the start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that the start vertex is processed (Processed = true) and has a Distance of 0.
Validation:
  This test confirms that the method correctly initializes and processes the simplest possible graph, setting the base case for more complex scenarios.

Scenario 3: Graph with Multiple Vertices

Details:
  TestName: ProcessMultiVertexGraphCorrectly
  Description: Verify that the method correctly processes a graph with multiple vertices, setting distances and predecessors.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple vertices and edges, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices are processed, have correct distances from the start vertex, and have appropriate predecessors set.
Validation:
  This test ensures that the core functionality of the BFS algorithm is working correctly for a typical use case with multiple vertices and edges.

Scenario 4: Disconnected Graph

Details:
  TestName: HandleDisconnectedGraphCorrectly
  Description: Ensure the method correctly processes a graph with disconnected components.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple disconnected components, and choose a start vertex in one component.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that vertices in the same component as the start vertex are processed and have distances set, while vertices in other components remain unprocessed with maximum distance.
Validation:
  This test confirms that the method correctly handles graphs that are not fully connected, which is an important edge case for graph algorithms.

Scenario 5: Cyclic Graph

Details:
  TestName: ProcessCyclicGraphWithoutInfiniteLoop
  Description: Verify that the method correctly processes a graph containing cycles without entering an infinite loop.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with cycles, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices are processed exactly once, have correct distances, and the method terminates.
Validation:
  This test ensures that the BFS algorithm correctly handles cycles in the graph, which is crucial for preventing infinite loops and ensuring correct distance calculations.

Scenario 6: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Ensure the method can process a large graph within a reasonable time frame.
Execution:
  Arrange: Create a BreadthFirstSearch instance, generate a large graph with many vertices and edges, and choose a start vertex.
  Act: Measure the time taken to call and complete the Run method with the large graph and start vertex.
  Assert: Verify that the method completes within an acceptable time limit and that all vertices are processed.
Validation:
  This test checks the performance characteristics of the BFS implementation, ensuring it scales well with larger inputs.

These test scenarios cover various aspects of the BreadthFirstSearch.Run method, including error handling, correct processing of different graph structures, and performance considerations. They aim to validate the method's correctness, robustness, and efficiency across different use cases.


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
            var startVertex = new Vertex<BFSVertex>(0, new BFSVertex());

            Assert.Throws<ArgumentNullException>(() => bfs.Run(null, startVertex));
        }

        [Test, Category("valid")]
        public void ProcessSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var startVertex = graph.AddVertex(new BFSVertex());

            bfs.Run(graph, startVertex);

            Assert.IsTrue(startVertex.Value.Processed);
            Assert.AreEqual(0, startVertex.Value.Distance);
        }

        [Test, Category("valid")]
        public void ProcessMultiVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            bfs.Run(graph, v1);

            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(2, v3.Value.Distance);
            Assert.AreEqual(v1, v2.Value.Predecessor);
            Assert.AreEqual(v2, v3.Value.Predecessor);
        }

        [Test, Category("valid")]
        public void HandleDisconnectedGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);

            bfs.Run(graph, v1);

            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsFalse(v3.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(int.MaxValue, v3.Value.Distance);
        }

        [Test, Category("valid")]
        public void ProcessCyclicGraphWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<BFSVertex>();
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            bfs.Run(graph, v1);

            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsTrue(v3.Value.Processed);
            Assert.AreEqual(0, v1.Value.Distance);
            Assert.AreEqual(1, v2.Value.Distance);
            Assert.AreEqual(1, v3.Value.Distance);
        }

        [Test, Category("valid")]
        public void ProcessLargeGraphWithinReasonableTime()
        {
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

            var startTime = DateTime.Now;
            bfs.Run(graph, vertices[0]);
            var endTime = DateTime.Now;

            Assert.Less((endTime - startTime).TotalSeconds, 5);
            Assert.IsTrue(vertices[9999].Value.Processed);
            Assert.AreEqual(9999, vertices[9999].Value.Distance);
        }
    }
}
