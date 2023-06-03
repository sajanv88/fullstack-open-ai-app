export type AppType = 'text_editor' | 'image_creator' | undefined;
export type IFormData = {
	input: string;
	instruction: string;
	processed?: boolean;
};

export interface IAPIResponseOfTextEditor {
	object: string;
	created: number;
	choices: Choice[];
	usage: Usage;
}

export interface Choice {
	text: string;
	index: number;
}

export interface Usage {
	promotTokens: number;
	completionTokens: number;
	totalTokens: number;
}

// image creator

export interface IFormImageCreatorData {
	prompt: string;
	n: number;
	size: string;
	processed?: boolean;
}
export interface IAPIResponseOfImageCreator {
	created: number;
	data: Datum[];
}

export interface Datum {
	url: string;
	b64Json: null;
}
