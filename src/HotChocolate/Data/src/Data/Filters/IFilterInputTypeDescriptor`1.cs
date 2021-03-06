using System;
using System.Linq.Expressions;
using HotChocolate.Language;
using HotChocolate.Types;

namespace HotChocolate.Data.Filters
{
    public interface IFilterInputTypeDescriptor
        : IDescriptor<FilterInputTypeDefinition>
        , IFluent
    {
        /// <summary>
        /// Defines the name of the <see cref="FilterInputType{T}"/>.
        /// </summary>
        /// <param name="value">The filter type name.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c> or
        /// <see cref="string.Empty"/>.
        /// </exception>
        IFilterInputTypeDescriptor Name(NameString value);

        /// <summary>
        /// Adds explanatory text of the <see cref="FilterInputType{T}"/>
        /// that can be accessed via introspection.
        /// </summary>
        /// <param name="value">The filter type description.</param>
        ///
        IFilterInputTypeDescriptor Description(string value);

        /// <summary>
        /// <para>Defines the filter binding behavior.</para>
        /// <para>
        /// The default binding behavior is set to
        /// <see cref="BindingBehavior.Implicit"/>.
        /// </para>
        /// </summary>
        /// <param name="bindingBehavior">
        /// The binding behavior.
        ///
        /// Implicit:
        /// The filter type descriptor will try to infer the filters
        /// from the specified <typeparamref name="T"/>.
        ///
        /// Explicit:
        /// All filters have to be specified explicitly via one of the `Filter`
        /// methods.
        /// </param>
        IFilterInputTypeDescriptor BindFields(
            BindingBehavior bindingBehavior);

        /// <summary>
        /// Defines that all filters have to be specified explicitly.
        /// </summary>
        IFilterInputTypeDescriptor BindFieldsExplicitly();

        /// <summary>
        /// The filter type will will add
        /// filters for all compatible fields.
        /// </summary>
        IFilterInputTypeDescriptor BindFieldsImplicitly();


        /// <summary>
        /// Defines a <see cref="FilterOperationField"> field.
        /// </summary>
        /// <param name="operation">
        /// The operation identifier for the operation
        /// </param>
        IFilterOperationFieldDescriptor Operation(int operation);

        /// <summary>
        /// Defines a <see cref="FilterField"> for the given property.
        /// </summary>
        /// <param name="property">
        /// The property for which a field should be created
        /// </param>
        IFilterFieldDescriptor Field(NameString name);

        /// <summary>
        /// Ignore the specified property.
        /// </summary>
        /// ram name="property">The property that hall be ignored.</param>
        IFilterInputTypeDescriptor Ignore(NameString name);

        /// <summary>
        /// Ignore the specified property.
        /// </summary>
        /// ram name="property">The property that hall be ignored.</param>
        IFilterInputTypeDescriptor Ignore(int operation);

        IFilterInputTypeDescriptor Directive<TDirective>(
            TDirective directiveInstance)
            where TDirective : class;

        IFilterInputTypeDescriptor Directive<TDirective>()
            where TDirective : class, new();

        IFilterInputTypeDescriptor Directive(
            NameString name,
            params ArgumentNode[] arguments);
    }

    public interface IFilterInputTypeDescriptor<T>
        : IFilterInputTypeDescriptor
    {
        /// <summary>
        /// Defines the name of the <see cref="FilterInputType{T}"/>.
        /// </summary>
        /// <param name="value">The filter type name.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c> or
        /// <see cref="string.Empty"/>.
        /// xception>
        new IFilterInputTypeDescriptor<T> Name(NameString value);

        /// <summary>
        /// Adds explanatory text of the <see cref="FilterInputType{T}"/>
        /// that can be accessed via introspection.
        /// </summary>
        /// <param name="value">The filter type description.</param>
        ///
        new IFilterInputTypeDescriptor<T> Description(string value);

        /// <summary>
        /// <para>Defines the filter binding behavior.</para>
        /// <para>
        /// The default binding behavior is set to
        /// <see cref="BindingBehavior.Implicit"/>.
        /// </para>
        /// </summary>
        /// <param name="bindingBehavior">
        /// The binding behavior.
        ///
        /// Implicit:
        /// The filter type descriptor will try to infer the filters
        /// from the specified <typeparamref name="T"/>.
        ///
        /// Explicit:
        /// All filters have to be specified explicitly via one of the `Filter`
        /// methods.
        /// aram>
        new IFilterInputTypeDescriptor<T> BindFields(
            BindingBehavior bindingBehavior);

        /// <summary>
        /// Defines that all filters have to be specified explicitly.
        /// ummary>
        new IFilterInputTypeDescriptor<T> BindFieldsExplicitly();

        /// <summary>
        /// The filter type will will add
        /// filters for all compatible fields.
        /// ummary>
        new IFilterInputTypeDescriptor<T> BindFieldsImplicitly();


        /// <summary>
        /// Defines a <see cref="FilterOperationField"> field.
        /// </summary>
        /// <param name="operation">
        /// The operation identifier for the operation
        /// </param>
        new IFilterOperationFieldDescriptor Operation(int operation);

        /// <summary>
        /// Defines a <see cref="FilterField"> for the given property.
        /// </summary>
        /// <param name="property">
        /// The property for which a field should be created
        /// </param>
        IFilterFieldDescriptor Operation<TField>(
            Expression<Func<T, TField>> method);

        /// <summary>
        /// Defines a <see cref="FilterField"> for the given property.
        /// </summary>
        /// <param name="property">
        /// The property for which a field should be created
        /// </param>
        IFilterFieldDescriptor Field<TField>(
            Expression<Func<T, TField>> property);

        /// <summary>
        /// Ignore the specified property.
        /// </summary>
        /// ram name="property">The property that hall be ignored.</param>
        IFilterInputTypeDescriptor<T> Ignore(
            Expression<Func<T, object>> property);

        /// <summary>
        /// Ignore the specified property.
        /// </summary>
        /// ram name="property">The property that hall be ignored.</param>
        new IFilterInputTypeDescriptor Ignore(NameString name);

        /// <summary>
        /// Ignore the specified property.
        /// </summary>
        /// ram name="property">The property that hall be ignored.</param>
        new IFilterInputTypeDescriptor Ignore(int operation);

        new IFilterInputTypeDescriptor<T> Directive<TDirective>(
            TDirective directiveInstance)
            where TDirective : class;
        new IFilterInputTypeDescriptor<T> Directive<TDirective>()
            where TDirective : class, new();
        new IFilterInputTypeDescriptor<T> Directive(
            NameString name,
            params ArgumentNode[] arguments);
    }
}
