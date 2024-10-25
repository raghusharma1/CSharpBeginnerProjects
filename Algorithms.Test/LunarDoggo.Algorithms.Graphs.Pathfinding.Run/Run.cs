// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_bbc3b7dcfd
ROOST_METHOD_SIG_HASH=Run_23f9485d25

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `BreadthFirstSearch` class:

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
  Assert: Verify that the start vertex's distance is 0 and it's marked as processed.
Validation:
  This test confirms that the method correctly initializes and processes a trivial graph case, setting the correct distance and processed state for the single vertex.

Scenario 3: Graph with Multiple Vertices

Details:
  TestName: ProcessMultiVertexGraphCorrectly
  Description: Verify that the method correctly processes a graph with multiple vertices, setting correct distances and predecessors.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple vertices and edges, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices are processed, have correct distances from the start vertex, and have correct predecessors set.
Validation:
  This test ensures that the BFS algorithm correctly traverses a more complex graph, assigning proper distances and predecessors to all vertices.

Scenario 4: Disconnected Graph

Details:
  TestName: HandleDisconnectedGraphCorrectly
  Description: Ensure the method correctly processes a disconnected graph, leaving unreachable vertices unprocessed.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with multiple disconnected components, and choose a start vertex in one component.
  Act: Call the Run method with the graph and start vertex.
  Assert: Verify that vertices in the same component as the start vertex are processed and have correct distances, while vertices in other components remain unprocessed with maximum distance.
Validation:
  This test confirms that the BFS algorithm correctly handles disconnected graphs, processing only the reachable vertices and leaving others untouched.

Scenario 5: Cyclic Graph

Details:
  TestName: ProcessCyclicGraphWithoutInfiniteLoop
  Description: Verify that the method correctly processes a graph containing cycles without entering an infinite loop.
Execution:
  Arrange: Create a BreadthFirstSearch instance, a graph with cycles, and choose a start vertex.
  Act: Call the Run method with the graph and start vertex.
  Assert: Check that all vertices are processed, have correct distances, and the method terminates in a finite time.
Validation:
  This test ensures that the BFS algorithm can handle cyclic graphs without getting stuck in an infinite loop, correctly assigning distances based on the shortest path to each vertex.

Scenario 6: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Ensure the method can process a large graph within a reasonable time frame.
Execution:
  Arrange: Create a BreadthFirstSearch instance, generate a large graph with many vertices and edges, and choose a start vertex.
  Act: Measure the time taken to call and complete the Run method with the large graph and start vertex.
  Assert: Verify that the method completes within an acceptable time limit and that all vertices are correctly processed.
Validation:
  This test checks the performance characteristics of the BFS implementation, ensuring it can handle large graphs efficiently without excessive time complexity.

These test scenarios cover various aspects of the BreadthFirstSearch.Run method, including error handling, correct processing of different graph types and sizes, and performance considerations.


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
            Assert.That(vertex.Value.Distance, Is.EqualTo(0));
            Assert.That(vertex.Value.Processed, Is.True);
            Assert.That(vertex.Value.Predecessor, Is.Null);
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
            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(2));
            Assert.That(v1.Value.Predecessor, Is.Null);
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v2));
            Assert.That(v1.Value.Processed && v2.Value.Processed && v3.Value.Processed, Is.True);
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
            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(int.MaxValue));
            Assert.That(v1.Value.Processed && v2.Value.Processed, Is.True);
            Assert.That(v3.Value.Processed, Is.False);
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
            Assert.That(v1.Value.Distance, Is.EqualTo(0));
            Assert.That(v2.Value.Distance, Is.EqualTo(1));
            Assert.That(v3.Value.Distance, Is.EqualTo(1));
            Assert.That(v1.Value.Processed && v2.Value.Processed && v3.Value.Processed, Is.True);
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
            var duration = (endTime - startTime).TotalSeconds;
            Assert.That(duration, Is.LessThan(5)); // Assuming 5 seconds is a reasonable time limit
            Assert.That(vertices.TrueForAll(v => v.Value.Processed), Is.True);
        }
    }
}
