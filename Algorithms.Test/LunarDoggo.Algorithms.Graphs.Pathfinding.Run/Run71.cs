// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_a2e9436d0a
ROOST_METHOD_SIG_HASH=Run_9ce955ed80

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `DepthFirstSearch` class:

Scenario 1: Null Graph Input

Details:
  TestName: ThrowArgumentNullExceptionForNullGraph
  Description: Verify that the method throws an ArgumentNullException when a null graph is provided.
Execution:
  Arrange: Create a DepthFirstSearch instance.
  Act: Call the Run method with a null graph.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input, preventing potential null reference exceptions later in the execution.

Scenario 2: Empty Graph

Details:
  TestName: ProcessEmptyGraphWithoutException
  Description: Ensure the method can handle an empty graph without throwing exceptions.
Execution:
  Arrange: Create a DepthFirstSearch instance and an empty IGraph<DFSVertex>.
  Act: Call the Run method with the empty graph.
  Assert: Verify that no exception is thrown and the method completes successfully.
Validation:
  This test confirms that the method can handle edge cases like empty graphs gracefully.

Scenario 3: Single Vertex Graph

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Check if the method correctly processes a graph with a single vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with one vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Verify that the vertex's StartTime and EndTime are set and Processed is true.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Connected Graph Processing

Details:
  TestName: ProcessAllVerticesInConnectedGraph
  Description: Verify that all vertices in a connected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a connected IGraph<DFSVertex> with multiple vertices.
  Act: Call the Run method with the connected graph.
  Assert: Check that all vertices have been processed (Processed is true for all).
Validation:
  This test confirms that the DFS algorithm visits all vertices in a connected graph.

Scenario 5: Disconnected Graph Processing

Details:
  TestName: ProcessAllComponentsInDisconnectedGraph
  Description: Ensure that all components of a disconnected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a disconnected IGraph<DFSVertex> with multiple components.
  Act: Call the Run method with the disconnected graph.
  Assert: Verify that all vertices in all components have been processed.
Validation:
  This test checks if the method correctly handles disconnected graphs by processing all components.

Scenario 6: Correct Start and End Times

Details:
  TestName: AssignCorrectStartAndEndTimes
  Description: Check if the start and end times are assigned correctly for each vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that for each vertex, StartTime < EndTime, and that the times are unique and sequential.
Validation:
  This test ensures that the core DFS timing logic is working correctly, which is crucial for applications like topological sorting.

Scenario 7: Correct Predecessor Assignment

Details:
  TestName: AssignCorrectPredecessors
  Description: Verify that predecessors are correctly assigned during the DFS traversal.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Check that each vertex (except the start vertex) has a correct predecessor assigned.
Validation:
  This test confirms that the DFS algorithm correctly builds the predecessor relationships, which is important for path reconstruction.

Scenario 8: Large Graph Performance

Details:
  TestName: ProcessLargeGraphWithinReasonableTime
  Description: Ensure the method can handle a large graph without excessive time consumption.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> (e.g., 10000+ vertices).
  Act: Call the Run method with the large graph and measure execution time.
  Assert: Verify that the method completes within a reasonable time frame and processes all vertices.
Validation:
  This test checks the performance characteristics of the DFS implementation for large inputs.

These test scenarios cover various aspects of the DepthFirstSearch.Run method, including input validation, edge cases, correctness of the algorithm, and performance considerations.


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
    public class Run71Test
    {
        private DepthFirstSearch dfs;

        [SetUp]
        public void Setup()
        {
            dfs = new DepthFirstSearch();
        }

        [Test, Category("invalid")]
        public void ThrowArgumentNullExceptionForNullGraph()
        {
            Assert.Throws<ArgumentNullException>(() => dfs.Run(null));
        }

        [Test, Category("boundary")]
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
        public void AssignCorrectStartAndEndTimes()
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
        public void AssignCorrectPredecessors()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            var startVertex = graph.Vertices.First(v => v.Value.Predecessor == null);
            Assert.That(startVertex, Is.Not.Null);

            foreach (var vertex in graph.Vertices.Where(v => v != startVertex))
            {
                Assert.That(vertex.Value.Predecessor, Is.Not.Null);
                Assert.That(vertex.Value.Predecessor.Adjacent.Contains(vertex), Is.True);
            }
        }

        [Test, Category("valid")]
        public void ProcessLargeGraphWithinReasonableTime()
        {
            var graph = CreateLargeGraph(10000);

            var startTime = DateTime.Now;
            dfs.Run(graph);
            var endTime = DateTime.Now;

            var duration = (endTime - startTime).TotalSeconds;
            Assert.That(duration, Is.LessThan(10)); // Assuming 10 seconds is reasonable
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
            // v3 and v4 are disconnected

            return graph;
        }

        private IGraph<DFSVertex> CreateLargeGraph(int vertexCount)
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertices = Enumerable.Range(0, vertexCount)
                                     .Select(_ => graph.AddVertex(new DFSVertex()))
                                     .ToList();

            for (int i = 1; i < vertexCount; i++)
            {
                graph.AddEdge(vertices[i - 1], vertices[i]);
            }

            return graph;
        }
    }
}
