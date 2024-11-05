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
  Assert: Verify that the vertex is marked as processed and its distance is set to 0.
Validation:
  This test confirms that the BFS algorithm works correctly for the simplest possible graph, setting the base case for more complex scenarios.

Scenario 3: Linear Graph Traversal

Details:
  TestName: TraverseLinearGraphCorrectly
  Description: Check if the BFS algorithm correctly traverses a linear graph (each vertex connected to at most two others).
Execution:
  Arrange: Create a linear graph with multiple vertices.
  Act: Run the BFS algorithm starting from one end of the graph.
  Assert: Verify that all vertices are processed in order, with distances increasing by 1 at each step.
Validation:
  This scenario tests the basic functionality of BFS in a simple, predictable graph structure, ensuring correct distance calculation and predecessor assignment.

Scenario 4: Cyclic Graph Handling

Details:
  TestName: HandleCyclicGraphWithoutInfiniteLoop
  Description: Verify that the BFS algorithm correctly handles a graph with cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a graph with at least one cycle.
  Act: Run the BFS algorithm on this graph.
  Assert: Check that all vertices are processed exactly once and have correct distances assigned.
Validation:
  This test ensures that the algorithm can handle more complex graph structures without issues, particularly focusing on the cycle detection and avoidance.

Scenario 5: Disconnected Graph Components

Details:
  TestName: ProcessOnlyReachableVerticesInDisconnectedGraph
  Description: Ensure that only vertices reachable from the start vertex are processed in a disconnected graph.
Execution:
  Arrange: Create a graph with multiple disconnected components.
  Act: Run the BFS algorithm starting from a vertex in one component.
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
  This test checks the efficiency and scalability of the BFS implementation, ensuring it can handle larger datasets without excessive time consumption.

Scenario 7: Correct Predecessor Assignment

Details:
  TestName: AssignCorrectPredecessorsInComplexGraph
  Description: Verify that the algorithm correctly assigns predecessors to vertices in a complex graph structure.
Execution:
  Arrange: Create a graph with multiple paths between vertices.
  Act: Run the BFS algorithm from a chosen start vertex.
  Assert: Check that each processed vertex (except the start) has a predecessor assigned, and that the predecessor is on a shortest path from the start vertex.
Validation:
  This scenario ensures that the predecessor assignment, which is crucial for path reconstruction, works correctly in various graph structures.

These test scenarios cover various aspects of the BreadthFirstSearch algorithm, including edge cases, error handling, and performance considerations. They aim to validate the correctness and robustness of the implementation across different graph structures and sizes.


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
        private BreadthFirstSearch bfs;
        private UndirectedUnweightedGraph<BFSVertex> graph;

        [SetUp]
        public void Setup()
        {
            bfs = new BreadthFirstSearch();
            graph = new UndirectedUnweightedGraph<BFSVertex>();
        }

        [Test, Category("invalid")]
        public void ThrowArgumentNullExceptionWhenGraphIsNull()
        {
            var start = new Vertex<BFSVertex>(0, new BFSVertex());
            Assert.Throws<ArgumentNullException>(() => bfs.Run(null, start));
        }

        [Test, Category("valid")]
        public void ProcessSingleVertexGraphCorrectly()
        {
            var vertex = graph.AddVertex(new BFSVertex());
            bfs.Run(graph, vertex);

            Assert.IsTrue(vertex.Value.Processed);
            Assert.AreEqual(0, vertex.Value.Distance);
        }

        [Test, Category("valid")]
        public void TraverseLinearGraphCorrectly()
        {
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
        public void HandleCyclicGraphWithoutInfiniteLoop()
        {
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
        public void ProcessOnlyReachableVerticesInDisconnectedGraph()
        {
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var v4 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v4);

            bfs.Run(graph, v1);

            Assert.IsTrue(v1.Value.Processed);
            Assert.IsTrue(v2.Value.Processed);
            Assert.IsFalse(v3.Value.Processed);
            Assert.IsFalse(v4.Value.Processed);
        }

        [Test, Category("valid")]
        public void CompleteTraversalOfLargeGraphWithinReasonableTime()
        {
            const int vertexCount = 10000;
            var vertices = Enumerable.Range(0, vertexCount).Select(_ => graph.AddVertex(new BFSVertex())).ToList();
            for (int i = 0; i < vertexCount - 1; i++)
            {
                graph.AddEdge(vertices[i], vertices[i + 1]);
            }

            var startTime = DateTime.Now;
            bfs.Run(graph, vertices[0]);
            var endTime = DateTime.Now;

            Assert.Less((endTime - startTime).TotalSeconds, 5); // Assuming 5 seconds is reasonable
            Assert.IsTrue(vertices.All(v => v.Value.Processed));
        }

        [Test, Category("valid")]
        public void AssignCorrectPredecessorsInComplexGraph()
        {
            var v1 = graph.AddVertex(new BFSVertex());
            var v2 = graph.AddVertex(new BFSVertex());
            var v3 = graph.AddVertex(new BFSVertex());
            var v4 = graph.AddVertex(new BFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v4);

            bfs.Run(graph, v1);

            Assert.AreEqual(v1, v2.Value.Predecessor);
            Assert.AreEqual(v1, v3.Value.Predecessor);
            Assert.AreEqual(v2, v4.Value.Predecessor); // v2 should be predecessor as it's encountered first
        }
    }
}
