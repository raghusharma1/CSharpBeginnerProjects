// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_a2e9436d0a
ROOST_METHOD_SIG_HASH=Run_9ce955ed80

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `DepthFirstSearch` class:

Scenario 1: Null Graph Input

Details:
  TestName: ThrowArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is passed as an argument.
Execution:
  Arrange: Create a DepthFirstSearch instance.
  Act: Call the Run method with a null graph.
  Assert: Verify that an ArgumentNullException is thrown with the correct message.
Validation:
  This test ensures that the method properly handles null input, preventing potential null reference exceptions later in the execution.

Scenario 2: Empty Graph

Details:
  TestName: ProcessEmptyGraphWithoutException
  Description: Ensure that the method can handle an empty graph (a graph with no vertices) without throwing an exception.
Execution:
  Arrange: Create a DepthFirstSearch instance and an empty IGraph<DFSVertex>.
  Act: Call the Run method with the empty graph.
  Assert: Verify that the method completes without throwing an exception.
Validation:
  This test confirms that the method can handle edge cases like empty graphs gracefully.

Scenario 3: Single Vertex Graph

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Verify that the method correctly processes a graph with a single vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with one vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Check that the vertex's StartTime and EndTime are set and Processed is true.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Connected Graph Processing

Details:
  TestName: ProcessAllVerticesInConnectedGraph
  Description: Ensure that all vertices in a connected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a connected IGraph<DFSVertex> with multiple vertices.
  Act: Call the Run method with the connected graph.
  Assert: Verify that all vertices have been processed (Processed is true for all vertices).
Validation:
  This test checks that the DFS algorithm visits all vertices in a connected graph.

Scenario 5: Disconnected Graph Processing

Details:
  TestName: ProcessAllComponentsInDisconnectedGraph
  Description: Verify that all components in a disconnected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a disconnected IGraph<DFSVertex> with multiple components.
  Act: Call the Run method with the disconnected graph.
  Assert: Check that all vertices in all components have been processed.
Validation:
  This test ensures that the method correctly handles disconnected graphs by processing all components.

Scenario 6: Correct Start and End Times

Details:
  TestName: AssignCorrectStartAndEndTimesToVertices
  Description: Ensure that start and end times are assigned correctly to all vertices.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that for each vertex, StartTime < EndTime, and that the times are unique and sequential.
Validation:
  This test checks the correctness of the time assignment aspect of the DFS algorithm.

Scenario 7: Proper Predecessor Assignment

Details:
  TestName: AssignCorrectPredecessorsToVertices
  Description: Verify that predecessors are correctly assigned to vertices during the DFS traversal.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Check that predecessors are assigned correctly based on the expected DFS traversal order.
Validation:
  This test ensures that the predecessor relationships are correctly established during the DFS process.

Scenario 8: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Ensure that the method can handle a large graph within a reasonable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> with many vertices and edges.
  Act: Call the Run method with the large graph and measure the execution time.
  Assert: Verify that the method completes within an acceptable time limit and processes all vertices.
Validation:
  This test checks the performance and scalability of the DFS implementation for large graphs.

These test scenarios cover various aspects of the `Run` method, including input validation, edge cases, correctness of the DFS algorithm implementation, and performance considerations.


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
    public class Run116Test
    {
        private DepthFirstSearch dfs;

        [SetUp]
        public void Setup()
        {
            dfs = new DepthFirstSearch();
        }

        [Test, Category("invalid")]
        public void ThrowArgumentNullExceptionWhenGraphIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => dfs.Run(null));
        }

        [Test, Category("valid")]
        public void ProcessEmptyGraphWithoutException()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            Assert.DoesNotThrow(() => dfs.Run(graph));
        }

        [Test, Category("valid")]
        public void ProcessSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex = graph.AddVertex(new DFSVertex());

            dfs.Run(graph);

            Assert.That(vertex.Value.Processed, Is.True);
            Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
            Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
        }

        [Test, Category("valid")]
        public void ProcessAllVerticesInConnectedGraph()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessAllComponentsInDisconnectedGraph()
        {
            var graph = CreateDisconnectedGraph();

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void AssignCorrectStartAndEndTimesToVertices()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            var vertices = graph.Vertices.ToList();
            for (int i = 0; i < vertices.Count; i++)
            {
                Assert.That(vertices[i].Value.StartTime, Is.LessThan(vertices[i].Value.EndTime));
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    Assert.That(vertices[i].Value.StartTime, Is.Not.EqualTo(vertices[j].Value.StartTime));
                    Assert.That(vertices[i].Value.EndTime, Is.Not.EqualTo(vertices[j].Value.EndTime));
                }
            }
        }

        [Test, Category("valid")]
        public void AssignCorrectPredecessorsToVertices()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            var vertices = graph.Vertices.ToList();
            Assert.That(vertices[0].Value.Predecessor, Is.Null);
            for (int i = 1; i < vertices.Count; i++)
            {
                Assert.That(vertices[i].Value.Predecessor, Is.Not.Null);
                Assert.That(vertices[i].Value.Predecessor.Adjacent.Contains(vertices[i]), Is.True);
            }
        }

        [Test, Category("valid")]
        public void ProcessLargeGraphWithinReasonableTime()
        {
            var graph = CreateLargeGraph();

            var startTime = DateTime.Now;
            dfs.Run(graph);
            var endTime = DateTime.Now;

            Assert.That((endTime - startTime).TotalSeconds, Is.LessThan(5));
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        private IGraph<DFSVertex> CreateConnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            var v4 = graph.AddVertex(new DFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v4, v1);

            return graph;
        }

        private IGraph<DFSVertex> CreateDisconnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            var v4 = graph.AddVertex(new DFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v4);

            return graph;
        }

        private IGraph<DFSVertex> CreateLargeGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertices = new Vertex<DFSVertex>[1000];

            for (int i = 0; i < 1000; i++)
            {
                vertices[i] = graph.AddVertex(new DFSVertex());
            }

            for (int i = 0; i < 999; i++)
            {
                graph.AddEdge(vertices[i], vertices[i + 1]);
            }

            return graph;
        }
    }
}
