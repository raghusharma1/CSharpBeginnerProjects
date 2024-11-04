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
  Description: Verify that the method throws an ArgumentNullException when a null graph is provided.
Execution:
  Arrange: Create a DepthFirstSearch instance with no graph.
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
  Description: Check if the method correctly processes a graph with only one vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a single vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Verify that the vertex is marked as processed and has valid start and end times.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Connected Graph Processing

Details:
  TestName: ProcessAllVerticesInConnectedGraph
  Description: Verify that all vertices in a connected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a connected IGraph<DFSVertex> with multiple vertices.
  Act: Call the Run method with the connected graph.
  Assert: Check that all vertices are marked as processed and have valid start and end times.
Validation:
  This test confirms that the method correctly traverses all vertices in a connected graph.

Scenario 5: Disconnected Graph Processing

Details:
  TestName: ProcessAllComponentsInDisconnectedGraph
  Description: Ensure that all components of a disconnected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a disconnected IGraph<DFSVertex> with multiple components.
  Act: Call the Run method with the disconnected graph.
  Assert: Verify that all vertices across all components are processed and have valid start and end times.
Validation:
  This test checks if the method can handle disconnected graphs and process all components independently.

Scenario 6: Correct Start and End Times

Details:
  TestName: AssignCorrectStartAndEndTimes
  Description: Verify that start and end times are assigned correctly and in the right order.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Check that for each vertex, the start time is less than the end time, and that the times are consistent with the DFS order.
Validation:
  This test ensures that the timing mechanism in the DFS algorithm is working correctly.

Scenario 7: Predecessor Assignment

Details:
  TestName: AssignCorrectPredecessors
  Description: Check if predecessors are correctly assigned during the DFS traversal.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that each vertex (except the start vertex) has a correct predecessor assigned.
Validation:
  This test confirms that the DFS algorithm correctly builds the predecessor relationships, which is crucial for path reconstruction.

Scenario 8: Graph With Cycles

Details:
  TestName: HandleGraphWithCyclesCorrectly
  Description: Ensure that the method can process a graph containing cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> containing at least one cycle.
  Act: Call the Run method with the cyclic graph.
  Assert: Verify that all vertices are processed and have valid start and end times.
Validation:
  This test checks if the method can handle graphs with cycles, which is important for robustness in real-world scenarios.

These test scenarios cover various aspects of the `Run` method, including edge cases, different graph structures, and key functionalities of the Depth-First Search algorithm.


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
    public class Run336Test
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

            Assert.IsTrue(vertex.Value.Processed);
            Assert.Greater(vertex.Value.StartTime, -1);
            Assert.Greater(vertex.Value.EndTime, vertex.Value.StartTime);
        }

        [Test, Category("valid")]
        public void ProcessAllVerticesInConnectedGraph()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            foreach (var vertex in graph.Vertices)
            {
                Assert.IsTrue(vertex.Value.Processed);
                Assert.Greater(vertex.Value.StartTime, -1);
                Assert.Greater(vertex.Value.EndTime, vertex.Value.StartTime);
            }
        }

        [Test, Category("valid")]
        public void ProcessAllComponentsInDisconnectedGraph()
        {
            var graph = CreateDisconnectedGraph();

            dfs.Run(graph);

            foreach (var vertex in graph.Vertices)
            {
                Assert.IsTrue(vertex.Value.Processed);
                Assert.Greater(vertex.Value.StartTime, -1);
                Assert.Greater(vertex.Value.EndTime, vertex.Value.StartTime);
            }
        }

        [Test, Category("valid")]
        public void AssignCorrectStartAndEndTimes()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            var vertices = graph.Vertices.OrderBy(v => v.Value.StartTime).ToList();
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                Assert.Less(vertices[i].Value.StartTime, vertices[i + 1].Value.StartTime);
                Assert.Less(vertices[i].Value.StartTime, vertices[i].Value.EndTime);
            }
        }

        [Test, Category("valid")]
        public void AssignCorrectPredecessors()
        {
            var graph = CreateConnectedGraph();

            dfs.Run(graph);

            var rootVertex = graph.Vertices.FirstOrDefault(v => v.Value.Predecessor == null);
            Assert.IsNotNull(rootVertex);

            foreach (var vertex in graph.Vertices.Where(v => v != rootVertex))
            {
                Assert.IsNotNull(vertex.Value.Predecessor);
                Assert.IsTrue(vertex.Value.Predecessor.Adjacent.Contains(vertex));
            }
        }

        [Test, Category("valid")]
        public void HandleGraphWithCyclesCorrectly()
        {
            var graph = CreateCyclicGraph();

            dfs.Run(graph);

            foreach (var vertex in graph.Vertices)
            {
                Assert.IsTrue(vertex.Value.Processed);
                Assert.Greater(vertex.Value.StartTime, -1);
                Assert.Greater(vertex.Value.EndTime, vertex.Value.StartTime);
            }
        }

        private IGraph<DFSVertex> CreateConnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
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

        private IGraph<DFSVertex> CreateCyclicGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);
            return graph;
        }
    }
}
