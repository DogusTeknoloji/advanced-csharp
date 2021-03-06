﻿using System;

namespace AdvancedCSharp {

    class Program {

        static void Main(string[] args) {
            // RunTutorial<Inheritance>();
            // RunTutorial<Events>();
            // RunTutorial<Reflection>();
            // RunTutorial<Attributes>();
            // RunTutorial<Indexers>();

            // RunTutorial<Partial>();
            // RunTutorial<Generics>();
            // RunTutorial<Nullable>();
            // RunTutorial<Iterators>();

            // RunTutorial<AnonTypes>();
            // RunTutorial<ExtensionMethods>();
            // RunTutorial<Lambda>();
            // RunTutorial<Linq>();

            // RunTutorial<Dynamic>();
            // RunTutorial<Variance>();

            // RunTutorial<Async>();
            // RunTutorial<CallerInfo>();

            // RunTutorial<StaticImports>();
            // RunTutorial<PropertyInitializers>();
            // RunTutorial<ExpressionBody>();
            // RunTutorial<ExceptionFilter>();
            // RunTutorial<NullPropagator>();
            // RunTutorial<StringInterpolation>();
            // RunTutorial<NameOf>();

            // RunTutorial<OutVar>();
            // RunTutorial<Tuples>();
            // RunTutorial<PatternMatching>();
            // RunTutorial<LocalFunctions>();
            // RunTutorial<RefLocalReturn>();
            // RunTutorial<DefaultLiterals>();
            // RunTutorial<Discards>();
            // RunTutorial<NumericImprovements>();
            // RunTutorial<PrivateProtected>();

            // RunTutorial<ReadonlyMembers>();
            // RunTutorial<NullableReferenceTypes>();
            // RunTutorial<DefaultInterfaceMembers>();
            // RunTutorial<AsyncStreams>();
            // RunTutorial<MorePatternMatching>();
            // RunTutorial<RangeIndicies>();
            // RunTutorial<UsingDeclarations>();
            // RunTutorial<NullCoalescingAssignment>();

            Console.ReadKey();
        }

        public static void RunTutorial<T>() where T: ITutorial, new() {
            new T().Run();
        }
    }
}
