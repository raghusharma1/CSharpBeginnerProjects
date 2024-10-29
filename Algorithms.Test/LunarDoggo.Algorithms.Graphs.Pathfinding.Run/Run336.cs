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

Scenario 4: Disconnected Graph

Details:
  TestName: ProcessAllVerticesInDisconnectedGraph
  Description: Ensure that all vertices in a disconnected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple disconnected vertices.
  Act: Call the Run method with the disconnected graph.
  Assert: Verify that all vertices have been processed (Processed is true for all).
Validation:
  This test checks that the method correctly handles disconnected graphs by processing all vertices.

Scenario 5: Cyclic Graph

Details:
  TestName: HandleCyclicGraphWithoutInfiniteLoop
  Description: Verify that the method can process a graph containing cycles without entering an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a cycle.
  Act: Call the Run method with the cyclic graph.
  Assert: Check that all vertices are processed and have valid StartTime and EndTime values.
Validation:
  This test ensures that the method can handle graphs with cycles, which is crucial for preventing infinite recursion.

Scenario 6: Correct Start and End Times

Details:
  TestName: AssignCorrectStartAndEndTimesToVertices
  Description: Ensure that the method assigns correct and increasing start and end times to vertices.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that for each vertex, StartTime < EndTime, and that times are assigned in the correct order based on the DFS traversal.
Validation:
  This test checks the core functionality of the DFS algorithm, ensuring that the timing mechanism works correctly.

Scenario 7: Correct Predecessor Assignment

Details:
  TestName: AssignCorrectPredecessorsToVertices
  Description: Verify that the method correctly assigns predecessors to vertices during traversal.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Check that each vertex (except the start vertex) has a correct predecessor assigned.
Validation:
  This test ensures that the method correctly builds the DFS tree by assigning proper predecessors.

Scenario 8: Large Graph Performance

Details:
  TestName: ProcessLargeGraphInReasonableTime
  Description: Ensure that the method can process a large graph within a reasonable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> (e.g., 10000 vertices).
  Act: Call the Run method with the large graph and measure the execution time.
  Assert: Verify that the method completes within an acceptable time limit and that all vertices are processed.
Validation:
  This test checks the performance and scalability of the method for large inputs.

These test scenarios cover various aspects of the `Run` method, including edge cases, error handling, correctness of the algorithm, and performance considerations.


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
        public void ProcessAllVerticesInDisconnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void HandleCyclicGraphWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void AssignCorrectStartAndEndTimesToVertices()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            dfs.Run(graph);

            Assert.That(v1.Value.StartTime, Is.LessThan(v2.Value.StartTime));
            Assert.That(v2.Value.StartTime, Is.LessThan(v3.Value.StartTime));
            Assert.That(v3.Value.EndTime, Is.LessThan(v2.Value.EndTime));
            Assert.That(v2.Value.EndTime, Is.LessThan(v1.Value.EndTime));
        }

        [Test, Category("valid")]
        public void AssignCorrectPredecessorsToVertices()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            dfs.Run(graph);

            Assert.That(v1.Value.Predecessor, Is.Null);
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v2));
        }

        [Test, Category("integration")]
        public void ProcessLargeGraphInReasonableTime()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertices = Enumerable.Range(0, 10000).Select(_ => graph.AddVertex(new DFSVertex())).ToList();

            for (int i = 1; i < vertices.Count; i++)
            {
                graph.AddEdge(vertices[i - 1], vertices[i]);
            }

            Assert.That(() => dfs.Run(graph), Throws.Nothing.And.CompletesBefore(TimeSpan.FromSeconds(5)));
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }
    }
}
