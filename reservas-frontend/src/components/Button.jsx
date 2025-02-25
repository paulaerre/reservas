import className from "classnames";
import { twMerge } from "tailwind-merge";

function Button({
  children,
  primary,
  warning,
  success,
  selected,
  active,
  ...rest
}) {
  const btnClassNames = twMerge(
    className(
      rest.className,
      "flex items-center px-3 py-1.5 border cursor-pointer rounded-xl",
      {
        "border-blue-500 bg-blue-500 text-white": primary && !selected,
        "border-red-500 bg-red-500 text-white": warning && !selected,
        "border-green-500 bg-green-500 text-white": success && !selected,
        "bg-gray-400 cursor-not-allowed": !active,
        "bg-blue-300 border-blue-400": selected && primary,
        "bg-red-300 border-red-400": selected && warning,
        "bg-green-300 border-green-400": selected && success,
      }
    )
  );

  return (
    <button {...rest} className={btnClassNames} disabled={!active}>
      {children}
    </button>
  );
}

export default Button;
